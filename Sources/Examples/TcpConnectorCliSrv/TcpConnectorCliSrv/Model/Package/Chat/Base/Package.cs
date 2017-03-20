using System;

namespace xPhoneShared.SocketStream.Package
{
    public class Package : PackageBase
    {
        public MessageTypes Type { get; set; }

        public Package(byte[] messageBytes)
        {
            SetupFromByteArray(messageBytes, 0);
        }

        public Package(MessageTypes type)
        {
            Type = type;
        }

        public override int GetLength()
        {
            return 1;
        }

        protected override void SetupFromByteArray(byte[] packetBytes, int offset)
        {
            Type = (MessageTypes)packetBytes[0];
        }

        protected virtual int GetLocalContentLength()
        {
            return 0;
        }

        public override void CopyContent(byte[] outBuffer, int offset)
        {
            outBuffer[offset] = (byte)Type;
        }

        public override string ToString()
        {
            return Enum.GetName( typeof(MessageTypes), (byte)Type);
        }

    }
}
