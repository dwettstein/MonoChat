using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WebEng_Chat
{
    public partial class ChatForm : Form, IChatForm
    {
        private ChatClient chatClient;

        public ChatForm()
        {
            InitializeComponent();
            chatClient = new ChatClient(this, "Reto");
        }

        private void txMsg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txMsg.Text.Length > 0)
            {
                chatClient.SendMessage(txMsg.Text);
                txMsg.Text = "";
            }
        }

        public void MessageReceived(string msg)
        {
            if (txContent.InvokeRequired)
            {
                txContent.Invoke(new MethodInvoker(() => MessageReceived(msg)));
                return;
            }

            txContent.AppendText(msg + "\r\n");
        }

        void ChatForm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            chatClient.Disconnect();
        }
    }
}
