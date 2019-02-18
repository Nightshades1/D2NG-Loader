/*Diablo II Next Gen Loader allowing starting modders to load 
 * their custom DLL(s) without the need of patching Fog or D2Win, 
 * also preventing access violation and weird behavior.
 * 
    Copyright(C) 2019  Valentin Fort

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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace D2NG_Loader
{
    class Win32
    {
       [DllImport("kernel32.dll",ExactSpelling = true, SetLastError = true)]
       public static extern IntPtr CreateRemoteThread(IntPtr hProcess,IntPtr lpThreadAttributes,UInt32 dwStackSize,IntPtr lpStartAddress,IntPtr lpParameter,UInt32 dwCreationFlags,out Int32 lpThreadId);

       [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
       public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, UInt32 dwSize, AllocationType flAllocationType, MemoryProtection flProtect);

       [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
       public static extern IntPtr OpenProcess(ProcessAccess dwDesiredAccess, Boolean bInheritHandle, UInt32 dwProcessId);

       [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
       public static extern IntPtr GetProcAddress(IntPtr hModule, String lpProcName);

       [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Ansi)]
       public static extern IntPtr GetModuleHandleA(String lpModuleName);

       [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
       public static extern Boolean CloseHandle(IntPtr hObject);

       [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
       public static extern Boolean WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, Byte[] lpBuffer, UInt32 nSize, out Int32 lpNumberOfBytesWritten);

       [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
       public static extern Boolean TerminateThread(IntPtr hThread, out UInt32 dwExitCode);

       [DllImport("kernel32.dll",ExactSpelling = true, SetLastError = true)]
       public static extern Boolean VirtualFreeEx(IntPtr hProcess,IntPtr lpAddress,UInt32 dwSize,FreeType dwFreeType);

       [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
       public static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds);
    }
    [Flags]
    enum ProcessAccess : UInt32
    {
        PROCESS_TERMINATE = 0x0001,
        PROCESS_CREATE_THREAD = 0x0002,
        PROCESS_SET_SESSIONID = 0x0004,
        PROCESS_VM_OPERATION = 0x0008,
        PROCESS_VM_READ = 0x0010,
        PROCESS_VM_WRITE = 0x0020,
        PROCESS_DUP_HANDLE = 0x0040,
        PROCESS_CREATE_PROCESS = 0x0080,
        PROCESS_SET_QUOTA = 0x0100,
        PROCESS_SET_INFORMATION = 0x0200,
        PROCESS_QUERY_INFORMATION = 0x0400,
        PROCESS_SUSPEND_RESUME = 0x0800,
        PROCESS_QUERY_LIMITED_INFORMATION = 0x1000,
        PROCESS_SET_LIMITED_INFORMATION = 0x2000,
        SYNCHRONIZE = 0x00100000,
        STANDARD_RIGHTS_REQUIRED = 0x000F0000,
        PROCESS_ALL_ACCESS = (STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE)
    }
    [Flags]
    enum FreeType
    {
        MEM_DECOMMIT = 0x00004000,
        MEM_RELEASE = 0x00008000,
        MEM_FREE = 0x00010000,
    }
    [Flags]
    enum AllocationType : UInt32
    {
        MEM_COMMIT = 0x00001000,
        MEM_RESERVE = 0x00002000,
        MEM_REPLACE_PLACEHOLDER = 0x00004000,
        MEM_RESERVE_PLACEHOLDER = 0x00040000,
        MEM_RESET = 0x00080000,
        MEM_TOP_DOWN = 0x00100000,
        MEM_WRITE_WATCH = 0x00200000,
        MEM_PHYSICAL = 0x00400000,
        MEM_ROTATE = 0x00800000,
        MEM_DIFFERENT_IMAGE_BASE_OK = 0x00800000,
        MEM_RESET_UNDO = 0x01000000,
        MEM_LARGE_PAGES = 0x20000000,
        MEM_4MB_PAGES = 0x80000000,
        MEM_64K_PAGES = (MEM_LARGE_PAGES | MEM_PHYSICAL),
        MEM_UNMAP_WITH_TRANSIENT_BOOST = 0x00000001,
        MEM_COALESCE_PLACEHOLDERS = 0x00000001,
        MEM_PRESERVE_PLACEHOLDER = 0x00000002,
    }
    [Flags]
    enum MemoryProtection : UInt32
    {
        PAGE_NOACCESS = 0x01,
        PAGE_READONLY = 0x02,
        PAGE_READWRITE = 0x04,
        PAGE_WRITECOPY = 0x08,
        PAGE_EXECUTE = 0x10,
        PAGE_EXECUTE_READ = 0x20,
        PAGE_EXECUTE_READWRITE = 0x40,
        PAGE_EXECUTE_WRITECOPY = 0x80,
        PAGE_GUARD = 0x100,
        PAGE_NOCACHE = 0x200,
        PAGE_WRITECOMBINE = 0x400,
        PAGE_ENCLAVE_THREAD_CONTROL = 0x80000000,
        PAGE_REVERT_TO_FILE_MAP = 0x80000000,
        PAGE_TARGETS_NO_UPDATE = 0x40000000,
        PAGE_TARGETS_INVALID = 0x40000000,
        PAGE_ENCLAVE_UNVALIDATED = 0x20000000,
        PAGE_ENCLAVE_DECOMMIT = 0x10000000,
    }
}


