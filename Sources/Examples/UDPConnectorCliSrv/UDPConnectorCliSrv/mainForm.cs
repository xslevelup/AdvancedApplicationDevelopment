using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Linq;

namespace UDPConnector
{
    public partial class mainForm : Form
    {
        private List<Client> clientCollection = new List<Client>();
        UdpClient client = null;
        bool isListening;

        public mainForm()
        {
            InitializeComponent();
        }

        #region UI event handlers

        private void listen_Click(object sender, EventArgs e)
        {
            if (isListening)
            {
                isListening = false;
            }
            else
            {
                StartListeningAsync();
            }
        }

        private void send_Click(object sender, EventArgs e)
        {
            Send();
        }

        private void clearLog_Click(object sender, EventArgs e)
        {
            log.Items.Clear();
        }

        #endregion

        private void AddLogItem(string descr, string message)
        {
            this.Invoke((MethodInvoker)delegate {
                log.Items.Add(string.Format("{0} {1}", descr, message));
            });
        }

        #region Listening

        #region Listening async

        private void StartListeningAsync()
        {
            try
            {
                client = new UdpClient();
                client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                client.ExclusiveAddressUse = false;
                client.Client.Bind(new IPEndPoint(IPAddress.Any, (int)listenPort.Value));

                AddLogItem("  !", "Start listening");

                client.BeginReceive(new AsyncCallback(this.ReceiveCallback), null);
            }
            catch (Exception ex)
            {
                AddLogItem("  E", ex.Message);
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                IPEndPoint remoteEndpoint = null;
                byte[] receivedBytes = client.EndReceive(ar, ref remoteEndpoint);
                UdpMessage resp = new UdpMessage(receivedBytes);

                ProcessResponse(remoteEndpoint, resp);

                if(resp.Type == UdpMessage.Types.close)
                {
                    StopListening();
                }
                else
                {
                    client.BeginReceive(new AsyncCallback(this.ReceiveCallback), null);
                }
            }
            catch (Exception ex)
            {
                AddLogItem("  E", ex.Message);
            }
        }

        #endregion

        private void ProcessResponse(IPEndPoint from, UdpMessage resp)
        {
            if (resp.Type != UdpMessage.Types.message)
            {
                AddLogItem(
                    string.Format("{0}:{1} ->", from.Address, from.Port),
                    resp.Text
                );
            }
            else
            {
                var sender = clientCollection.FirstOrDefault(x => String.Compare(x.Id, resp.Parameters[0]) == 0);

                AddLogItem(
                    sender != null ? string.Format("{0}:{1} ->", sender.Endpoint.Address, sender.Endpoint.Port) : "  N/A ->",
                    resp.Text
                );
            }

            switch (resp.Type)
            {
                case UdpMessage.Types.register:
                    clientCollection.Add(new Client(resp.Parameters[0], new IPEndPoint(from.Address, Convert.ToInt32(resp.Parameters[1]))));
                    break;

                case UdpMessage.Types.message:
                    ForwardMessage(resp.Parameters[0], resp.Parameters[1]);
                    break;

                case UdpMessage.Types.close:
                    break;
            }
        }

        private void ForwardMessage(string senderId, string message)
        {
            foreach (Client cli in clientCollection)
            {
                if (string.Compare(cli.Id, senderId) != 0)
                    SendMessage(cli.Endpoint, message);
            }
        }

        private void StopListening()
        {
            AddLogItem("  !", "Stop listening");
            isListening = false;
        }

        #endregion

        #region Sending

        private void Send()
        {
            IPAddress targetAddress = IPAddress.Parse(targetHost.Text);
            IPEndPoint targetEndpoint = new IPEndPoint(targetAddress, (int)targetPort.Value);

            AddLogItem("<-", message.Text);

            SendMessage(targetEndpoint, message.Text);
        }

        private void SendMessage(IPEndPoint targetEndpoint, string message)
        {
            byte[] send_buffer = Encoding.ASCII.GetBytes(message);

            try
            {
                UdpClient sender = new UdpClient();
                sender.Send(send_buffer, send_buffer.Length, targetEndpoint);
            }
            catch (Exception ex)
            {
                AddLogItem("  E", ex.Message);
            }
        }

        #endregion

    }
}
