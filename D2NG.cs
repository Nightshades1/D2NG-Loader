/*<Diablo II Next Gen Loader allowing starting modders to load 
 * their custom DLL(s) without the need of patching Fog or D2Win, 
 * also preventing access violation and weird behavior.>
    Copyright(C) <2019>  <Valentin Fort>

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.If not, see<https://www.gnu.org/licenses/>.*/
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

namespace D2NG_Loader
{
    class D2NG
    {
        private static Main MainForm;
        private static String[] ExcludeFilter = { "binkw32.dll", "Bnclient.dll", "D2Client.dll", "D2CMP.dll", "D2Common.dll", "D2DDraw.dll", "D2Direct3D.dll", "D2Game.dll", "D2Gdi.dll", "D2gfx.dll", "D2Glide.dll", "D2Lang.dll", "D2Launch.dll", "D2MCPClient.dll", "D2Multi.dll", "D2Net.dll", "D2sound.dll", "D2Win.dll", "Fog.dll", "glide3x.dll", "ijl11.dll", "Keyhook.dll", "SmackW32.dll", "Storm.dll", "D2Server.dll" };
        public static void SetForm(ref Main Form)
        {
            MainForm = Form;
        }
        public static void AddDLL()
        {
            if (MainForm.DLL_Picker_Listbox.SelectedItem != null)
            {
                MainForm.DLL_ToLoad_Listbox.Items.Add(MainForm.DLL_Picker_Listbox.SelectedItem);
                MainForm.DLL_Picker_Listbox.Items.Remove(MainForm.DLL_Picker_Listbox.SelectedItem);
                Properties.Settings.Default.DLLS.Clear();
                foreach (Object DLL in MainForm.DLL_ToLoad_Listbox.Items)
                {
                    Properties.Settings.Default.DLLS.Add(DLL);
                }
                Properties.Settings.Default.Save();
            }
        }
        public static void RemoveDLL()
        {
            if (MainForm.DLL_ToLoad_Listbox.SelectedItem != null)
            {
                MainForm.DLL_Picker_Listbox.Items.Add(MainForm.DLL_ToLoad_Listbox.SelectedItem);
                MainForm.DLL_ToLoad_Listbox.Items.Remove(MainForm.DLL_ToLoad_Listbox.SelectedItem);
            }
            Properties.Settings.Default.DLLS.Clear();
            foreach (Object DLL in MainForm.DLL_ToLoad_Listbox.Items)
            {
                Properties.Settings.Default.DLLS.Add(DLL);
            }
            Properties.Settings.Default.Save();
        }
        public static void IterateDLLS()
        {
            String[] Files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.dll", SearchOption.TopDirectoryOnly);
            foreach (String item in Files)
            {
                if (ExcludeFilter.Contains(Path.GetFileName(item)) || Properties.Settings.Default.DLLS.Contains(Path.GetFileName(item)))
                {
                    continue;
                }
                MainForm.DLL_Picker_Listbox.Items.Add(Path.GetFileName(item));
            }
        }
        public static void LoadSavedDLL()
        {
            if (Properties.Settings.Default.DLLS == null)
            {
                Properties.Settings.Default.DLLS = new System.Collections.ArrayList();
            }
            foreach (Object DLL in Properties.Settings.Default.DLLS)
            {
                MainForm.DLL_ToLoad_Listbox.Items.Add(DLL);
            }
        }
        public static void LaunchGame()
        {
            Properties.Settings.Default.Save();
            Int32 NumberOfBytesWritten;
            Int32 ThreadID;
            String GameDLL;
            Process gameProcess;
            try
            {
                 gameProcess = Process.Start("game.exe", MainForm.Parameter_TextBox.Text);
            }
            catch (Exception)
            {
                throw new Exception("I couldn't find game.exe, place me in your Diablo 2 Folder !");
            }
            foreach (Object DLL in Properties.Settings.Default.DLLS)
            {
                GameDLL = DLL.ToString();
                IntPtr LoadLibrary_Address = Win32.GetProcAddress(Win32.GetModuleHandleA("kernel32.dll"), "LoadLibraryA");
                IntPtr Alloc_DLLName = Win32.VirtualAllocEx(gameProcess.Handle, IntPtr.Zero, (UInt32)GameDLL.Length, AllocationType.MEM_COMMIT | AllocationType.MEM_RESERVE, MemoryProtection.PAGE_READWRITE);
                IntPtr OpenProcess = Win32.OpenProcess(ProcessAccess.PROCESS_ALL_ACCESS, false, (uint)gameProcess.Id);
                Win32.WriteProcessMemory(gameProcess.Handle, Alloc_DLLName, Encoding.Default.GetBytes(GameDLL), (uint)GameDLL.Length, out NumberOfBytesWritten);
                IntPtr RemoteThread = Win32.CreateRemoteThread(gameProcess.Handle, IntPtr.Zero, 0, LoadLibrary_Address, Alloc_DLLName, 0, out ThreadID);
                Win32.WaitForSingleObject(RemoteThread, 0xFFFFFFFF);
                Win32.CloseHandle(OpenProcess);
                Win32.VirtualFreeEx(gameProcess.Handle, Alloc_DLLName, 0, FreeType.MEM_RELEASE);
            }
        }
    }
}
