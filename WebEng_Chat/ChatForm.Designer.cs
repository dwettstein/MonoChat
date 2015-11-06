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
            this.SuspendLayout();
            // 
            // txMsg
            // 
            this.txMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txMsg.Location = new System.Drawing.Point(0, 420);
            this.txMsg.Name = "txMsg";
            this.txMsg.Size = new System.Drawing.Size(573, 31);
            this.txMsg.TabIndex = 0;
            this.txMsg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txMsg_KeyDown);
            // 
            // txContent
            // 
            this.txContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txContent.Location = new System.Drawing.Point(0, 0);
            this.txContent.Multiline = true;
            this.txContent.Name = "txContent";
            this.txContent.ReadOnly = true;
            this.txContent.Size = new System.Drawing.Size(573, 420);
            this.txContent.TabIndex = 1;
            this.txContent.TabStop = false;
            // 
            // ChatForm
            // 
            // this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            // this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 451);
            this.Controls.Add(this.txContent);
            this.Controls.Add(this.txMsg);
            this.Name = "ChatForm";
            this.Text = "Akka Chat";
            this.FormClosed += ChatForm_FormClosed;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txMsg;
        private System.Windows.Forms.TextBox txContent;
    }
}

