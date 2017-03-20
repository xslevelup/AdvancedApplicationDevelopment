using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testWCFclient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            //content.Text = GetDataDLL("http://localhost:63373/LoginService.svc");
            content.Text = GetDataProxy("http://localhost:63373/LoginService.svc");
            //content.Text = GetDataProxyClient();
            //content.Text = GetDataReferenceProxy("http://localhost:63373/LoginService.svc");
            //content.Text = GetDataReferenceProxyClient();

            //userList.DataSource = GetUsersDLL("http://localhost:63373/LoginService.svc");
            userList.DataSource = await GetUsersReferenceProxyClientAsync();
        }

        private string GetDataDLL(string accessPoint)
        {
            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress(accessPoint);
            ChannelFactory<testWCFsrv.ILoginService> myChannelFactory = new ChannelFactory<testWCFsrv.ILoginService>(myBinding, myEndpoint);

            testWCFsrv.ILoginService client = myChannelFactory.CreateChannel();

            string content = null;

            content = client.GetData();

            ((ICommunicationObject)client).Close();

            return content;
        }

        private string GetDataProxy(string accessPoint)
        {
            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress(accessPoint);
            ChannelFactory<ILoginService> myChannelFactory = new ChannelFactory<ILoginService>(myBinding, myEndpoint);

            ILoginService client = myChannelFactory.CreateChannel();

            string content = null;

            content = client.GetData();

            ((ICommunicationObject)client).Close();

            return content;
        }

        private string GetDataProxyClient()
        {
            LoginServiceClient client = new LoginServiceClient();

            string content = client.GetData();

            client.Close();

            return content;
        }

        private string GetDataReferenceProxy(string accessPoint)
        {
            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress(accessPoint);
            ChannelFactory<testWCFclient.LoginServiceReference.ILoginService> myChannelFactory = new ChannelFactory<testWCFclient.LoginServiceReference.ILoginService>(myBinding, myEndpoint);

            testWCFclient.LoginServiceReference.ILoginService client = myChannelFactory.CreateChannel();

            string content = null;

            content = client.GetData();

            ((ICommunicationObject)client).Close();

            return content;
        }

        private string GetDataReferenceProxyClient()
        {
            string content = null;

            testWCFclient.LoginServiceReference.LoginServiceClient client = new testWCFclient.LoginServiceReference.LoginServiceClient();

            content = client.GetData();

            client.Close();

            return content;
        }

        private List<testWCFsrv.User> GetUsersDLL(string accessPoint)
        {
            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress(accessPoint);
            ChannelFactory<testWCFsrv.ILoginService> myChannelFactory = new ChannelFactory<testWCFsrv.ILoginService>(myBinding, myEndpoint);

            testWCFsrv.ILoginService client = myChannelFactory.CreateChannel();

            List<testWCFsrv.User> users = client.GetUsers();

            ((ICommunicationObject)client).Close();

            return users;
        }

        private async Task<List<UserWithName>> GetUsersReferenceProxyClientAsync()
        {
            testWCFclient.LoginServiceReference.LoginServiceClient client = new testWCFclient.LoginServiceReference.LoginServiceClient();

            testWCFclient.LoginServiceReference.User[] srvUsers = await client.GetUsersAsync();

            client.Close();

            List<UserWithName> users = new List<UserWithName>();

            foreach(testWCFclient.LoginServiceReference.User user in srvUsers)
                users.Add(new UserWithName(user));

            return users;
        }
    }
}
