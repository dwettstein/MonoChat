namespace WebEng_Chat
{
    partial class ChatForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.txMsg = new System.Windows.Forms.TextBox();
            this.txContent = new System.Windows.Forms.TextBox();
            this.lbUsers = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToOneDriveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txMsg
            // 
            this.txMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txMsg.Location = new System.Drawing.Point(0, 420);
            this.txMsg.Name = "txMsg";
            this.txMsg.Size = new System.Drawing.Size(611, 31);
            this.txMsg.TabIndex = 0;
            this.txMsg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txMsg_KeyDown);
            // 
            // txContent
            // 
            this.txContent.Dock = System.Windows.Forms.DockStyle.Right;
            this.txContent.Location = new System.Drawing.Point(200, 40);
            this.txContent.Multiline = true;
            this.txContent.Name = "txContent";
            this.txContent.ReadOnly = true;
            this.txContent.Size = new System.Drawing.Size(411, 380);
            this.txContent.TabIndex = 1;
            this.txContent.TabStop = false;
            // 
            // lbUsers
            // 
            this.lbUsers.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbUsers.Enabled = false;
            this.lbUsers.FormattingEnabled = true;
            this.lbUsers.ItemHeight = 25;
            this.lbUsers.Location = new System.Drawing.Point(0, 40);
            this.lbUsers.Name = "lbUsers";
            this.lbUsers.Size = new System.Drawing.Size(194, 380);
            this.lbUsers.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(611, 40);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToOneDriveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 36);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToOneDriveToolStripMenuItem
            // 
            this.saveToOneDriveToolStripMenuItem.Name = "saveToOneDriveToolStripMenuItem";
            this.saveToOneDriveToolStripMenuItem.Size = new System.Drawing.Size(305, 38);
            this.saveToOneDriveToolStripMenuItem.Text = "Save To OneDrive";
            this.saveToOneDriveToolStripMenuItem.Click += new System.EventHandler(this.saveToOneDriveToolStripMenuItem_Click);
            // 
            // ChatForm
            // 
            this.ClientSize = new System.Drawing.Size(611, 451);
            this.Controls.Add(this.lbUsers);
            this.Controls.Add(this.txContent);
            this.Controls.Add(this.txMsg);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ChatForm";
            this.Text = "Mono Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatForm_FormClosing);
            this.SizeChanged += new System.EventHandler(this.ChatForm_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txMsg;
        private System.Windows.Forms.TextBox txContent;
        private System.Windows.Forms.ListBox lbUsers;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToOneDriveToolStripMenuItem;
    }
}

