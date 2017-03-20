using System;
using System.Collections.Generic;
using System.Text;

namespace xPhoneShared.SocketStream.Package
{
    class DeviceStatePackage : ContentPackage
    {
        public byte State { get; protected set; }
        public string SenderDeviceId { get; private set; }

        public DeviceStatePackage(byte[] messageBytes) : base(messageBytes)
        {

        }

        public DeviceStatePackage(MessageTypes type, byte state, string senderDeviceId) : base(type)
        {
            State = state;
            SenderDeviceId = senderDeviceId;
        }

        public override int GetLength()
        {
            return base.GetLength() + GetLocalContentLength();
        }

        protected new int GetLocalContentLength()
        {
            return 1 + 1 + Encoding.UTF8.GetByteCount(SenderDeviceId);
        }

        public override void CopyContent(byte[] outBuffer, int offset)
        {
            base.CopyContent(outBuffer, offset);

            offset += base.GetLength();
            outBuffer[offset] = State;
            offset += 1;
            offset = WriteTextBytes(outBuffer, offset, SenderDeviceId);
        }
    }
}
