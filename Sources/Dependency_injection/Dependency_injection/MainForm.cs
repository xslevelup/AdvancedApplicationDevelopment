using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace Dependency_injection
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        string databaseType;
        string databaseFile;

        string userName;

        private void Form1_Load(object sender, EventArgs e)
        {
            var appSettings = ConfigurationManager.AppSettings;
            databaseType = appSettings["databaseType"];
            databaseFile = appSettings["databaseFileName"];

            LoadUserName();

            UserNameInput.Text = userName;
        }

        private void LoadUserName()
        {
            try
            {
                byte[] fileBytes = File.ReadAllBytes(databaseFile);
                userName = Encoding.UTF8.GetString(fileBytes);
            }
            catch (Exception)
            {
                userName = "";
            }
        }

        private void SaveUserName()
        {
            userName = UserNameInput.Text;
            File.WriteAllBytes(databaseFile, Encoding.UTF8.GetBytes(userName));
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveUserName();
        }
    }
}
