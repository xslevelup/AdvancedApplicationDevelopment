using System;
using System.Collections.Generic;
using System.Text;

namespace xPhoneShared.SocketStream.Package
{
    class DeviceForwardReqPackage : ContentPackage
    {
        public string TargetId { get; private set; }
        public byte[] Content { get; private set; }

        public DeviceForwardReqPackage(byte[] messageBytes) : base(messageBytes)
        {
            int offset = base.GetLength();
            
            string strValue;
            offset = ReadTextBytes(messageBytes, offset, out strValue);
            TargetId = strValue;

            Content = new byte[messageBytes.Length - offset];
            Buffer.BlockCopy(messageBytes, offset, Content, 0, Content.Length);
        }

        public DeviceForwardReqPackage(string targetId, byte[] content) : base(MessageTypes.DeviceForwardReq)
        {
            TargetId = targetId;
            Content = content;
        }

        public override int GetLength()
        {
            return base.GetLength() + GetLocalContentLength();
        }

        protected new int GetLocalContentLength()
        {
            return 1 + Encoding.UTF8.GetByteCount(TargetId) + Content.Length;
        }

        public override void CopyContent(byte[] outBuffer, int offset)
        {
            base.CopyContent(outBuffer, 0);

            offset += base.GetLength();
            offset = WriteTextBytes(outBuffer, offset, TargetId);
            Buffer.BlockCopy(Content, 0, outBuffer, offset, Content.Length);
        }
    }
}
