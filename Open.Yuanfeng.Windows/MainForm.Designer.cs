namespace Open.Yuanfeng.Windows
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NwListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NwSwithToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consoleCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.vS2012LightTheme = new WeifenLuo.WinFormsUI.Docking.VS2012LightTheme();
            this.MainDockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.HelperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileFToolStripMenuItem,
            this.NetworkToolStripMenuItem,
            this.WindowsToolStripMenuItem,
            this.HelperToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(875, 24);
            this.MainMenuStrip.TabIndex = 0;
            // 
            // fileFToolStripMenuItem
            // 
            this.fileFToolStripMenuItem.Name = "fileFToolStripMenuItem";
            this.fileFToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.fileFToolStripMenuItem.Text = "File(&F)";
            // 
            // NetworkToolStripMenuItem
            // 
            this.NetworkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NwListToolStripMenuItem,
            this.NwSwithToolStripMenuItem});
            this.NetworkToolStripMenuItem.Name = "NetworkToolStripMenuItem";
            this.NetworkToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.NetworkToolStripMenuItem.Text = "Network(&N)";
            // 
            // NwListToolStripMenuItem
            // 
            this.NwListToolStripMenuItem.Name = "NwListToolStripMenuItem";
            this.NwListToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.NwListToolStripMenuItem.Text = "Interface List(&L)";
            // 
            // NwSwithToolStripMenuItem
            // 
            this.NwSwithToolStripMenuItem.Name = "NwSwithToolStripMenuItem";
            this.NwSwithToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.NwSwithToolStripMenuItem.Text = "Enable All(&E)";
            // 
            // WindowsToolStripMenuItem
            // 
            this.WindowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consoleCToolStripMenuItem});
            this.WindowsToolStripMenuItem.Name = "WindowsToolStripMenuItem";
            this.WindowsToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.WindowsToolStripMenuItem.Text = "Window(&W)";
            // 
            // consoleCToolStripMenuItem
            // 
            this.consoleCToolStripMenuItem.Name = "consoleCToolStripMenuItem";
            this.consoleCToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.consoleCToolStripMenuItem.Text = "Console(&C)";
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 435);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(875, 22);
            this.MainStatusStrip.TabIndex = 1;
            // 
            // MainDockPanel
            // 
            this.MainDockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainDockPanel.Location = new System.Drawing.Point(0, 24);
            this.MainDockPanel.Name = "MainDockPanel";
            this.MainDockPanel.Size = new System.Drawing.Size(875, 411);
            this.MainDockPanel.TabIndex = 2;
            this.MainDockPanel.Theme = this.vS2012LightTheme;
            // 
            // HelperToolStripMenuItem
            // 
            this.HelperToolStripMenuItem.Name = "HelperToolStripMenuItem";
            this.HelperToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.HelperToolStripMenuItem.Text = "Helper(&H)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 457);
            this.Controls.Add(this.MainDockPanel);
            this.Controls.Add(this.MainStatusStrip);
            this.Controls.Add(this.MainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenuStrip;
            this.Name = "MainForm";
            this.Text = "Yuanfeng Open Source Lib Test v1.0";
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NetworkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NwListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NwSwithToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WindowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consoleCToolStripMenuItem;
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private WeifenLuo.WinFormsUI.Docking.VS2012LightTheme vS2012LightTheme;
        private WeifenLuo.WinFormsUI.Docking.DockPanel MainDockPanel;
        private System.Windows.Forms.ToolStripMenuItem HelperToolStripMenuItem;
    }
}

