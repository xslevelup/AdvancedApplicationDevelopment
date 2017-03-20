using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcpConnectorCliSrv
{
    public partial class LoginForm : Form
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public LoginForm()
        {
            InitializeComponent();
        }
        private void LoginForm_Shown(object sender, EventArgs e)
        {
            userName.Text = UserName;
            password.Text = Password;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            UserName = userName.Text;
            Password = password.Text;

            this.Close();
        }

        public void Reset()
        {
            UserName = string.Empty;
            Password = string.Empty;
        }

    }
}
