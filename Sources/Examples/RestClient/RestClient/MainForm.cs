using System;
using System.Windows.Forms;

namespace RestClient
{
    public partial class MainForm : Form
    {
        MainViewModel ViewModel;

        public MainForm()
        {
            InitializeComponent();
            InitViewModel();
        }

        private void InitViewModel()
        {
            ViewModel = new MainViewModel();

            token.DataBindings.Add("Text", ViewModel, "Token");
            guess.DataBindings.Add("Text", ViewModel, "Guess");
            result.DataBindings.Add("Text", ViewModel, "Result");
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            ViewModel.Send();
        }

    }
}
