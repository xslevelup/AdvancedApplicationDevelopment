using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using xPhoneShared.SocketStream.Package;

namespace TcpConnectorCliSrv
{
    public class Client
    {
        public TcpClient Socket { get; set; }

        public string Id { get; set; }

        private NetworkStream netStream;
        private SslStream sslStream;
        private Stream selectedStream;

        private PackageManager packageManage;

        private byte[] readBuffer = new byte[2048];

        public static byte[] Delimiter { get; set; }

        public bool IsAuthenticatied { get; set; }

        public Client(TcpClient socket)
        {
            IsAuthenticatied = false;

            Socket = socket;
            netStream = Socket.GetStream();
            selectedStream = netStream;

            packageManage = new PackageManager(Delimiter[0]);
            packageManage.PingReceived += PackageManage_PingReceived;
            packageManage.LoginRequestReceived += PackageManage_LoginRequestReceived;
            packageManage.ForwardRequestReceived += PackageManage_ForwardRequestReceived;
            packageManage.CallRequestReceived += PackageManage_CallRequestReceived;
        }

        public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;

            //TODO: Chain error is accepted while using self signed cert
            if (sslPolicyErrors == SslPolicyErrors.RemoteCertificateChainErrors)
            {
                return true;
            }

            // By default do not allow this client to communicate with unauthenticated servers.
            return false;
        }

        #region API

        public event EventHandler<SocketCommunicationEventArgs> DataReceived = delegate { };
        public event EventHandler<SocketCommunicationEventArgs> DataSent = delegate { };

        public event EventHandler<PackageEventArgs> ForwardRequest = delegate { };

        public string EndpointInfo()
        {
            return string.Format(
                "{0}:{1}",
                ((IPEndPoint)Socket.Client.RemoteEndPoint).Address.ToString(),
                ((IPEndPoint)Socket.Client.RemoteEndPoint).Port.ToString()
                );
        }

        #region SSL Authenticatoin

        public void ClientSSLAuthentication()
        {
            sslStream = new SslStream(
                    netStream,
                    false,
                    new RemoteCertificateValidationCallback(ValidateServerCertificate),
                    null
                    );

            IPEndPoint endPoint = (IPEndPoint)Socket.Client.RemoteEndPoint;
            IPAddress ipAddress = endPoint.Address;

            sslStream.AuthenticateAsClient(ipAddress.ToString());

            selectedStream = sslStream;
        }

        public void ServerSSLAuthentication(string certPath, string certPassword)
        {
            X509Certificate2 certificate = new X509Certificate2(certPath, certPassword);

            sslStream = new SslStream(netStream);

            sslStream.AuthenticateAsServer(certificate);

            selectedStream = sslStream;
        }

        #endregion

        public void StartReceive()
        {
            selectedStream.BeginRead(readBuffer, 0, readBuffer.Length, new AsyncCallback(ReadCallback), selectedStream);
        }

        public void Send(byte[] buffer)
        {
            selectedStream.Write(buffer, 0, buffer.Length);
        }

        public async Task SendAsync(byte[] buffer)
        {
            await selectedStream.WriteAsync(buffer, 0, buffer.Length);
        }

        public void Close()
        {
            netStream.Close();
            Socket.Close();
        }

        #endregion

        #region Callbacks

        private void ReadCallback(IAsyncResult ar)
        {
            try
            {
                Stream stream = (Stream)ar.AsyncState;
                int byteCount = -1;

                byteCount = stream.EndRead(ar);

                if (byteCount > 0)
                {
                    byte[] outBuffer = new byte[byteCount];

                    Buffer.BlockCopy(readBuffer, 0, outBuffer, 0, byteCount);

                    DataReceived(this, new SocketCommunicationEventArgs(outBuffer));

                    packageManage.AddContent(outBuffer);

                    stream.BeginRead(readBuffer, 0, readBuffer.Length, new AsyncCallback(ReadCallback), stream);
                }
                else
                {
                    Close();
                }
            }
            catch(ObjectDisposedException)
            {

            }
            catch (IOException)
            {

            }
        }

        #endregion

        #region PackageManager evenet handlers

        private void PackageManage_PingReceived(object sender, PackageEventArgs e)
        {
            byte[] pongBytes = new PongPackage().GetBytes();

            Send(pongBytes);
            DataSent(this, new SocketCommunicationEventArgs(pongBytes));
        }

        private void PackageManage_LoginRequestReceived(object sender, PackageEventArgs e)
        {
            LoginReqPackage lrp = (LoginReqPackage)e.Package;

            Id = lrp.DeviceId;

            byte[] loginRespBytes = new LoginRespPackage().GetBytes();

            Send(loginRespBytes);
            DataSent(this, new SocketCommunicationEventArgs(loginRespBytes));
        }

        private void PackageManage_CallRequestReceived(object sender, PackageEventArgs e)
        {
            Random rnd = new Random();
            byte[] callRespBytes = new CallRespPackage(true, rnd.Next()).GetBytes();

            Send(callRespBytes);
            DataSent(this, new SocketCommunicationEventArgs(callRespBytes));
        }

        private void PackageManage_ForwardRequestReceived(object sender, PackageEventArgs e)
        {
            ForwardRequest(this, e);
        }

        #endregion
    }
}
