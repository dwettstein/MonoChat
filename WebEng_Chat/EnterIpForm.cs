using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebEng_Chat
{
    public partial class EnterIpForm : Form
    {
        public EnterIpForm()
        {
            InitializeComponent();
        }

        private void EnterIpForm_Load(object sender, EventArgs e)
        {
            txName.Focus();
        }

        private void txName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txName.Text.Trim().Length > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
