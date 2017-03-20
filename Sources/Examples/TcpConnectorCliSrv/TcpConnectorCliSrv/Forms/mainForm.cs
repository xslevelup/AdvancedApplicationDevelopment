using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using TcpConnectorCliSrv.Model.User;
using xPhoneShared.SocketStream;
using xPhoneShared.SocketStream.Package;

namespace TcpConnectorCliSrv
{
    public partial class MainForm : Form
    {
        TcpListener listener = null;
        Client client = null;
        List<Client> clients = new List<Client>();

        UserStore userStore;

        #region Form lifecycle events

        public MainForm()
        {
            InitializeComponent();

            IPAddress localAddr = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(x => x.IsIPv6LinkLocal == false);

            targetHost.Items.Add("127.0.0.1");
            targetHost.Items.Add(localAddr.ToString());

            localHost.Items.AddRange(targetHost.Items.OfType<string>().ToArray());

            PackageBase.Delimiter = Convert.ToByte('|');
            Client.Delimiter = new byte[] { Convert.ToByte('|') };
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopClients();

            Disconnect();
        }

        #endregion

        #region UI event handlers

        private void clearLog_Click(object sender, EventArgs e)
        {
            log.Items.Clear();
        }

        private void browseCert_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Personal Information exchange (*.pfx)|*.pfx";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                certFile.Text = ofd.FileName;
            }
        }

        private void browseUserListFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Coma separated text values (*.csv)|*.csv";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                userListFile.Text = ofd.FileName;
            }
        }

        private void listen_Click(object sender, EventArgs e)
        {
            try {
                if (listener == null)
                {
                    if (userListFile.Text.Length > 0)
                    {
                        userStore = new UserStore(userListFile.Text);
                    }
                    else
                    {
                        userStore = null;
                    }

                    StartListening();
                    listen.Text = "Stop";
                }
                else
                {
                    listener.Stop();
                    StopClients();
                    listen.Text = "Listen";
                }
            }
            catch (Exception ex)
            {
                AddLogItem("  E", ex.Message);
            }
        }

        private void connect_Click(object sender, EventArgs e)
        {
            try
            {
                if (client == null)
                {
                    LoginForm loginForm = new LoginForm();

                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        Connect();
                        connect.Text = "Disconnect";
                    }
                }
                else
                {
                    Disconnect();
                    connect.Text = "Connect";
                    AddLogItem("  !", "Disconnect");
                }
            }
            catch (Exception ex)
            {
                AddLogItem("  E", ex.Message);
            }
        }

        private void send_Click(object sender, EventArgs e)
        {
            byte[] buffer = null;

            if (binaryData.Checked == true)
            {
                buffer = HexToByte(message.Text);
            }
            else
            {
                buffer = Encoding.UTF8.GetBytes(message.Text);
            }

            if (sendServer.Checked == true)
            {
                SendToServer(buffer);
            }

            if (sendClients.Checked == true)
            {
                SendToClients(buffer, null);
            }
        }

        #endregion

        private byte[] HexToByte(string hexString)
        {
            List<byte> bytes = new List<byte>();
            string hexByte;

            if (hexString.Length % 2 == 1)
            {
                hexString = string.Format("0{0}", hexString);
            }

            while (hexString.Length > 2)
            {
                hexByte = hexString.Substring(0, 2);
                hexString = hexString.Substring(2);
                bytes.Add(Convert.ToByte(hexByte, 16));
            }

            bytes.Add(Convert.ToByte(hexString, 16));

            return bytes.ToArray();
        }

        #region UI modifiers

        private string LogData(byte[] data)
        {
            if (binaryData.Checked == true)
            {
                return BitConverter.ToString(data).Replace("-", "");
            }
            else
            {
                return Encoding.UTF8.GetString(data);
            }
        }

        private void AddLogItem(string descr, string message)
        {
            this.Invoke((MethodInvoker)delegate {
                log.Items.Add(string.Format("{0} {1}", descr, message));
            });
        }

        private void ShowClientCount()
        {
            this.Invoke((MethodInvoker)delegate {
                clientCount.Text = clients.Count.ToString();
            });
        }

        #endregion

        #region TCP connection

        #region Server

        private void StartListening()
        {
            listener = null;

            AddLogItem("  !", "Start listening");

            IPAddress localAddr = IPAddress.Parse(localHost.Text);
            listener = new TcpListener(localAddr, (int)listenPort.Value);

            listener.Start();

            listener.BeginAcceptTcpClient(new AsyncCallback(OnClientAccept), listener);
        }

        private void OnClientAccept(IAsyncResult iar)
        {
            try
            {
                TcpClient tcpClient = listener.EndAcceptTcpClient(iar);

                Client client = new Client(tcpClient);

                if(certFile.Text.Length > 0)
                {
                    client.ServerSSLAuthentication(certFile.Text, certPassword.Text);
                }

                client.DataReceived += Client_DataReceived;
                client.DataSent += Client_DataSent;
                client.ForwardRequest += Client_ForwardRequest;
                client.StartReceive();

                clients.Add(client);
                ShowClientCount();

                listener.BeginAcceptTcpClient(new AsyncCallback(OnClientAccept), listener);
            }
            catch (SocketException ex)
            {
                AddLogItem("  E", ex.Message);
            }
            catch (ObjectDisposedException)
            {
                AddLogItem("  !", "Stop listening");
                listener = null;
            }

        }

        private void StopClients()
        {
            foreach (Client c in clients)
            {
                c.Close();
            }
            clients.Clear();
            ShowClientCount();
        }

        private void Client_DataReceived(object sender, SocketCommunicationEventArgs e)
        {
            Client client = (Client)sender;
            var port = ((IPEndPoint)client.Socket.Client.RemoteEndPoint).Port;

            AddLogItem(" <-", string.Format("{0}: [{1}] {2}", port, e.Data.Length, LogData(e.Data)));

            if (forwardOnServer.Checked == true)
            {
                SendToClients(e.Data, client);
            }
        }

        private void Client_DataSent(object sender, SocketCommunicationEventArgs e)
        {
            AddLogItem(" ->", string.Format("{0}: [{1}] {2}", ((Client)sender).EndpointInfo(), e.Data.Length, LogData(e.Data)));
        }

        private void Client_ForwardRequest(object sender, xPhoneShared.SocketStream.Package.PackageEventArgs e)
        {
            DeviceForwardReqPackage frp = (DeviceForwardReqPackage)e.Package;

            Client target = clients.FirstOrDefault(x => x.Id.Equals(frp.TargetId));

            if(target != null)
            {
                target.Send(frp.Content);
            }
        }

        private void SendToClients(byte[] data, Client excludedClient)
        {
            foreach (Client c in clients)
            {
                if (c != excludedClient)
                {
                    c.Send(data);
                }
            }
        }

        #endregion

        #region Client

        private void Connect()
        {
            TcpClient clientSocket = new TcpClient(targetHost.Text, (int)targetPort.Value);
            client = new Client(clientSocket);

            if (useSSL.Checked == true)
            {
                client.ClientSSLAuthentication();
            }

            client.StartReceive();
            client.DataReceived += Client_DataReceived;

            AddLogItem("  !", "Connect");
        }

        private void Disconnect()
        {
            if (client != null)
            {
                client.Close();

                client = null;
            }
        }

        private void SendToServer(byte[] buffer)
        {
            if (client != null)
            {
                client.Send(buffer);
            }
        }


        #endregion

        #endregion

    }
}
