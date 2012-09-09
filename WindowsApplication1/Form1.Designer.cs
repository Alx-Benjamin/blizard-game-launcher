namespace WindowsApplication1
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openfile = new System.Windows.Forms.OpenFileDialog();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settings = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Add = new System.Windows.Forms.Button();
            this.exelocation = new System.Windows.Forms.Button();
            this.location = new System.Windows.Forms.TextBox();
            this.CloseSettings = new System.Windows.Forms.Button();
            this._main = new System.Windows.Forms.Panel();
            this.Exit = new System.Windows.Forms.Button();
            this.menu.SuspendLayout();
            this.settings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this._main.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(507, 24);
            this.menu.TabIndex = 3;
            this.menu.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // settings
            // 
            this.settings.Controls.Add(this.groupBox1);
            this.settings.Controls.Add(this.CloseSettings);
            this.settings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settings.Location = new System.Drawing.Point(0, 0);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(507, 277);
            this.settings.TabIndex = 4;
            this.settings.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Add);
            this.groupBox1.Controls.Add(this.exelocation);
            this.groupBox1.Controls.Add(this.location);
            this.groupBox1.Location = new System.Drawing.Point(31, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 74);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add";
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(371, 32);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 5;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // exelocation
            // 
            this.exelocation.Location = new System.Drawing.Point(15, 29);
            this.exelocation.Name = "exelocation";
            this.exelocation.Size = new System.Drawing.Size(75, 23);
            this.exelocation.TabIndex = 3;
            this.exelocation.Text = "File Location";
            this.exelocation.UseVisualStyleBackColor = true;
            this.exelocation.Click += new System.EventHandler(this.exelocation_Click_1);
            // 
            // location
            // 
            this.location.Location = new System.Drawing.Point(109, 32);
            this.location.Name = "location";
            this.location.Size = new System.Drawing.Size(237, 20);
            this.location.TabIndex = 4;
            this.location.TextChanged += new System.EventHandler(this.location_TextChanged);
            // 
            // CloseSettings
            // 
            this.CloseSettings.Location = new System.Drawing.Point(394, 227);
            this.CloseSettings.Name = "CloseSettings";
            this.CloseSettings.Size = new System.Drawing.Size(89, 23);
            this.CloseSettings.TabIndex = 6;
            this.CloseSettings.Text = "Close Settings";
            this.CloseSettings.UseVisualStyleBackColor = true;
            this.CloseSettings.Click += new System.EventHandler(this.CloseSettings_Click);
            // 
            // _main
            // 
            this._main.Controls.Add(this.Exit);
            this._main.Dock = System.Windows.Forms.DockStyle.Fill;
            this._main.Location = new System.Drawing.Point(0, 0);
            this._main.Name = "_main";
            this._main.Size = new System.Drawing.Size(507, 277);
            this._main.TabIndex = 7;
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(420, 227);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 1;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 277);
            this.ControlBox = false;
            this.Controls.Add(this.menu);
            this.Controls.Add(this.settings);
            this.Controls.Add(this._main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menu;
            this.Name = "Main";
            this.Text = "Windows 7 Old School Game Launcher";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.settings.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this._main.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openfile;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Panel settings;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.TextBox location;
        private System.Windows.Forms.Button exelocation;
        private System.Windows.Forms.Panel _main;
        private System.Windows.Forms.Button CloseSettings;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

