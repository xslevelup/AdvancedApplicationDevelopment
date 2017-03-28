using System;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Dependency_injection
{
    public partial class MainForm : Form
    {
        string databaseType;
        string databaseFile;

        string userName;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var appSettings = ConfigurationManager.AppSettings;
            databaseType = appSettings["databaseType"];
            databaseFile = appSettings["databaseFileName"];

            LoadUserName();

            UserNameInput.Text = userName;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveUserName();
        }

        private void LoadUserName()
        {
            try
            {
                var userNameHex = File.ReadAllText(databaseFile);
                var userNameBytes = Enumerable.Range(0, userNameHex.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(userNameHex.Substring(x, 2), 16))
                     .ToArray();
                userName = Encoding.UTF8.GetString(userNameBytes);

                //userName = File.ReadAllText(databaseFile);
            }
            catch (Exception)
            {
                userName = "";
            }
        }

        private void SaveUserName()
        {
            userName = UserNameInput.Text;

            var userNameBytes = Encoding.UTF8.GetBytes(userName);
            string userNameHex = BitConverter.ToString(userNameBytes).Replace("-", string.Empty);
            File.WriteAllText(databaseFile, userNameHex);
            
            //File.WriteAllText(databaseFile, userName);
        }
    }
}