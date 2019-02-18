using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace D2NG_Loader
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            Main MainForm = this;
            D2NG.SetForm(ref MainForm);
        }

        private void LaunchGame_Button_Click(object sender, EventArgs e)
        {
            D2NG.LaunchGame();
        }

        private void DLL_Picker_Add_Button_Click(object sender, EventArgs e)
        {
            D2NG.AddDLL();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            D2NG.LoadSavedDLL();
            D2NG.IterateDLLS();
        }

        private void Parameter_OnTextChanged_TextBox(object sender, EventArgs e)
        {
            Properties.Settings.Default.Args = Parameter_TextBox.Text;
            Properties.Settings.Default.Save();
        }

        private void DLL_ToLoad_Remove_OnClick(object sender, EventArgs e)
        {
            D2NG.RemoveDLL();
        }
    }
}
