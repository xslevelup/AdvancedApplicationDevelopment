using System;
using System.Collections.Generic;
using System.Text;

namespace xPhoneShared.SocketStream.Package
{

    class PackageManager
    {
        private const int TYPE_BYTE_COUNT = 2;
        private const int SIZE_BYTE_COUNT = 2;

        private const int MAX_MESSAGE_LENGTH = 1024;

        private byte delimiter;

        List<byte> content;
        bool isContentInvalid;

        #region API

        public event EventHandler<PackageEventArgs> PingReceived = delegate { };
        public event EventHandler<PackageEventArgs> PongReceived = delegate { };
        public event EventHandler<PackageEventArgs> LoginRequestReceived = delegate { };
        public event EventHandler<PackageEventArgs> LoginResponseReceived = delegate { };
        public event EventHandler<PackageEventArgs> CallRequestReceived = delegate { };
        public event EventHandler<PackageEventArgs> CallResponseReceived = delegate { };
        public event EventHandler<PackageEventArgs> ForwardRequestReceived = delegate { };
        public event EventHandler<PackageEventArgs> ForwardResponseReceived = delegate { };
        public event EventHandler<PackageEventArgs> RingRequestReceived = delegate { };

        public PackageManager(byte delimiter)
        {
            isContentInvalid = false;
            content = new List<byte>();
            this.delimiter = delimiter;
        }

        public void Reset()
        {
            content.Clear();
            isContentInvalid = false;
        }

        public void AddContent(byte[] newContent)
        {
            StoreMessagePartIfValid(newContent);

            if (isContentInvalid == false)
            {
                CheckMessageEnds();

                ValidateMessageLength();
            }
        }

        #endregion

        #region Message processing

        private void StoreMessagePartIfValid(byte[] newContent)
        {
            content.AddRange(newContent);

            if(isContentInvalid)
            {
                var index = content.FindIndex(x => (x == delimiter));

                if (index>=0)
                {
                    content.RemoveRange(0, index + 1);
                    isContentInvalid = false;
                }
                else
                {
                    content.Clear();
                }
            }
        }

        private void CheckMessageEnds()
        {
            bool haveFullMessage = false;
            int index;
            while ((index = content.FindIndex(x => (x == delimiter))) >= 0)
            {
                haveFullMessage = GetContent(index);
            }
        }

        private bool GetContent(int endsAt)
        {
            if (content.Count >= endsAt)
            {
                if (endsAt <= MAX_MESSAGE_LENGTH)
                {
                    byte[] messageData = new byte[endsAt];
                    for (int i = 0; i < endsAt; i++)
                        messageData[i] = content[i];

                    ProcessMessage(messageData);
                }

                content.RemoveRange(0, endsAt + 1);

                return true;
            }

            return false;
        }

        private void ProcessMessage(byte[] messageData)
        {
            MessageTypes type = (MessageTypes)messageData[0];

            switch (type)
            {
                case MessageTypes.Ping:
                    PingReceived(this, new PackageEventArgs(new PingPackage(messageData)));
                    break;

                case MessageTypes.Pong:
                    PongReceived(this, new PackageEventArgs(new PongPackage(messageData)));
                    break;

                case MessageTypes.LoginReq:
                    LoginRequestReceived(this, new PackageEventArgs(new LoginReqPackage(messageData)));
                    break;

                case MessageTypes.LoginResp:
                    LoginResponseReceived(this, new PackageEventArgs(new LoginRespPackage(messageData)));
                    break;

                case MessageTypes.CallReq:
                    CallRequestReceived(this, new PackageEventArgs(new CallReqPackage(messageData)));
                    break;

                case MessageTypes.CallResp:
                    CallResponseReceived(this, new PackageEventArgs(new CallRespPackage(messageData)));
                    break;

                case MessageTypes.DeviceForwardReq:
                    ForwardRequestReceived(this, new PackageEventArgs(new DeviceForwardReqPackage(messageData)));
                    break;

                case MessageTypes.DeviceForwardResp:
                    ForwardResponseReceived(this, new PackageEventArgs(new DeviceForwardRespPackage(messageData)));
                    break;

                case MessageTypes.RingReq:
                    RingRequestReceived(this, new PackageEventArgs(new RingReqPackage(messageData)));
                    break;
            }
        }

        private void ValidateMessageLength()
        {
            if (content.Count > MAX_MESSAGE_LENGTH)
            {
                content.Clear();
                isContentInvalid = true;
            }
        }

        #endregion
    }
}
