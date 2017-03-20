using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UseSQLite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DBConnection dbConn = new DBConnection(@"database\default.sqlite");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = dbConn.GetVersion();
        }

        private void InitisolatedStorage()
        {
            IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Application, null, null);
        }
    }
}
