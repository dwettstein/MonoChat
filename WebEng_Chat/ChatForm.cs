using Microsoft.OneDrive.Sdk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WebEng_Chat.OneDrive;

namespace WebEng_Chat
{
    public partial class ChatForm : Form, IChatForm
    {
        private const string OneDriveClientID = "000000004416D320";
        private string serverIp = "localhost";
        private string serverPort = "8081";
        private ChatClient chatClient;
        private IOneDriveClient oneDriveClient = null;

        public ChatForm()
        {
            InitializeComponent();
            EnterServerIp();
            chatClient = new ChatClient(this, serverIp, serverPort);
            ChangeContentSize();
            DoLogin();
        }

        private void EnterServerIp()
        {
            EnterIpForm enterIpForm = new EnterIpForm();
            if (enterIpForm.ShowDialog(this) == DialogResult.OK)
            {
                string enteredText = enterIpForm.txName.Text;
                if (enteredText.Contains(":"))
                {
                    string[] textParts = enteredText.Split(':');
                    serverIp = textParts[0];
                    serverPort = textParts[1];
                }
                else
                {
                    serverIp = enteredText;
                }
            }
            else
            {
                serverIp = "localhost";

            }
            enterIpForm.Dispose();
        }

        private void DoLogin()
        {
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog(this) == DialogResult.OK)
            {
                chatClient.RegisterMessage(loginForm.txName.Text);
            }
            else
            {
                chatClient.RegisterMessage("Anonymous");
            }
            loginForm.Dispose();
        }

        private async void saveToOneDriveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (oneDriveClient == null)
            {
                oneDriveClient = OneDriveClient.GetMicrosoftAccountClient(
                    OneDriveClientID,
                    "https://login.live.com/oauth20_desktop.srf",
                    new string[] { "onedrive.readwrite", "wl.offline_access", "wl.signin" },
                    webAuthenticationUi: new FormsWebAuthenticationUi());
            }

            try
            {
                if (!oneDriveClient.IsAuthenticated)
                {
                    await oneDriveClient.AuthenticateAsync();
                }
            }
            catch (OneDriveException)
            {
                MessageBox.Show("Authentication failed", "Error", MessageBoxButtons.OK);
                return;
            }

            try
            {
                var tmpFile = System.IO.Path.GetTempFileName();
                System.IO.File.WriteAllText(tmpFile, txContent.Text);
                var stream = new System.IO.FileStream(tmpFile, System.IO.FileMode.Open);
                var filename = DateTime.Now.ToString("yyyy_MM_dd_mm_ss") + "_MonoChat.txt";
                var uploadPath = @"/drive/items/root:/" + filename;
                var uploadedItem =
                    await
                        this.oneDriveClient.ItemWithPath(uploadPath).Content.Request().PutAsync<Item>(stream);

                MessageBox.Show("Chat histroy saved!", "Success", MessageBoxButtons.OK);
                stream.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Chat histroy could not be saved!", "Error", MessageBoxButtons.OK);
            }
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

        public void OnlineUsersChanged(string[] users)
        {
            if (lbUsers.InvokeRequired)
            {
                lbUsers.Invoke(new MethodInvoker(() => OnlineUsersChanged(users)));
                return;
            }

            lbUsers.Items.Clear();
            lbUsers.Items.AddRange(users);
        }

        private void ChangeContentSize()
        {
            txContent.Width = this.Width - lbUsers.Width - 20;
        }

        private void ChatForm_SizeChanged(object sender, EventArgs e)
        {
            ChangeContentSize();
        }

        private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (chatClient != null)
            {
                chatClient.Disconnect();
            }
        }
    }
}
