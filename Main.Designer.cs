namespace D2NG_Loader
{
    partial class Main
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.DLL_Picker_Listbox = new System.Windows.Forms.ListBox();
            this.LaunchGame_Button = new System.Windows.Forms.Button();
            this.Custom_DLL_Label = new System.Windows.Forms.Label();
            this.DLL_Picker_Add_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DLL_ToLoad_Listbox = new System.Windows.Forms.ListBox();
            this.DLL_ToLoad_Remove_Button = new System.Windows.Forms.Button();
            this.Parameter_TextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // DLL_Picker_Listbox
            // 
            this.DLL_Picker_Listbox.FormattingEnabled = true;
            this.DLL_Picker_Listbox.Location = new System.Drawing.Point(239, 39);
            this.DLL_Picker_Listbox.Name = "DLL_Picker_Listbox";
            this.DLL_Picker_Listbox.Size = new System.Drawing.Size(120, 251);
            this.DLL_Picker_Listbox.TabIndex = 6;
            // 
            // LaunchGame_Button
            // 
            this.LaunchGame_Button.Location = new System.Drawing.Point(95, 296);
            this.LaunchGame_Button.Name = "LaunchGame_Button";
            this.LaunchGame_Button.Size = new System.Drawing.Size(217, 83);
            this.LaunchGame_Button.TabIndex = 1;
            this.LaunchGame_Button.Text = "Launch Game";
            this.LaunchGame_Button.UseVisualStyleBackColor = true;
            this.LaunchGame_Button.Click += new System.EventHandler(this.LaunchGame_Button_Click);
            // 
            // Custom_DLL_Label
            // 
            this.Custom_DLL_Label.AutoSize = true;
            this.Custom_DLL_Label.Location = new System.Drawing.Point(53, 23);
            this.Custom_DLL_Label.Name = "Custom_DLL_Label";
            this.Custom_DLL_Label.Size = new System.Drawing.Size(108, 13);
            this.Custom_DLL_Label.TabIndex = 5;
            this.Custom_DLL_Label.Text = "Custom DLL To Load";
            // 
            // DLL_Picker_Add_Button
            // 
            this.DLL_Picker_Add_Button.Location = new System.Drawing.Point(173, 124);
            this.DLL_Picker_Add_Button.Name = "DLL_Picker_Add_Button";
            this.DLL_Picker_Add_Button.Size = new System.Drawing.Size(60, 23);
            this.DLL_Picker_Add_Button.TabIndex = 7;
            this.DLL_Picker_Add_Button.Text = "Add";
            this.DLL_Picker_Add_Button.UseVisualStyleBackColor = true;
            this.DLL_Picker_Add_Button.Click += new System.EventHandler(this.DLL_Picker_Add_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(238, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Select Your Custom DLL";
            // 
            // DLL_ToLoad_Listbox
            // 
            this.DLL_ToLoad_Listbox.AllowDrop = true;
            this.DLL_ToLoad_Listbox.FormattingEnabled = true;
            this.DLL_ToLoad_Listbox.Location = new System.Drawing.Point(47, 39);
            this.DLL_ToLoad_Listbox.Name = "DLL_ToLoad_Listbox";
            this.DLL_ToLoad_Listbox.Size = new System.Drawing.Size(120, 251);
            this.DLL_ToLoad_Listbox.Sorted = true;
            this.DLL_ToLoad_Listbox.TabIndex = 4;
            // 
            // DLL_ToLoad_Remove_Button
            // 
            this.DLL_ToLoad_Remove_Button.Location = new System.Drawing.Point(173, 153);
            this.DLL_ToLoad_Remove_Button.Name = "DLL_ToLoad_Remove_Button";
            this.DLL_ToLoad_Remove_Button.Size = new System.Drawing.Size(60, 23);
            this.DLL_ToLoad_Remove_Button.TabIndex = 10;
            this.DLL_ToLoad_Remove_Button.Text = "Remove";
            this.DLL_ToLoad_Remove_Button.UseVisualStyleBackColor = true;
            this.DLL_ToLoad_Remove_Button.Click += new System.EventHandler(this.DLL_ToLoad_Remove_OnClick);
            // 
            // Parameter_TextBox
            // 
            this.Parameter_TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::D2NG_Loader.Properties.Settings.Default, "Args", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Parameter_TextBox.Location = new System.Drawing.Point(95, 385);
            this.Parameter_TextBox.Name = "Parameter_TextBox";
            this.Parameter_TextBox.Size = new System.Drawing.Size(217, 20);
            this.Parameter_TextBox.TabIndex = 0;
            this.Parameter_TextBox.Text = global::D2NG_Loader.Properties.Settings.Default.Args;
            this.Parameter_TextBox.TextChanged += new System.EventHandler(this.Parameter_OnTextChanged_TextBox);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 434);
            this.Controls.Add(this.DLL_ToLoad_Remove_Button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DLL_Picker_Add_Button);
            this.Controls.Add(this.DLL_Picker_Listbox);
            this.Controls.Add(this.Custom_DLL_Label);
            this.Controls.Add(this.DLL_ToLoad_Listbox);
            this.Controls.Add(this.LaunchGame_Button);
            this.Controls.Add(this.Parameter_TextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "D2NG-Loader";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox Parameter_TextBox;
        public System.Windows.Forms.Button LaunchGame_Button;
        private System.Windows.Forms.Label Custom_DLL_Label;
        public System.Windows.Forms.Button DLL_Picker_Add_Button;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ListBox DLL_Picker_Listbox;
        public System.Windows.Forms.ListBox DLL_ToLoad_Listbox;
        public System.Windows.Forms.Button DLL_ToLoad_Remove_Button;
    }
}

