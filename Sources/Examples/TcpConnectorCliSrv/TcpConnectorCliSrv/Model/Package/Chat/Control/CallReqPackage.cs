using System;
using System.Collections.Generic;
using System.Text;

namespace xPhoneShared.SocketStream.Package
{
    class CallReqPackage : ContentPackage
    {
        public Int32 CallerUserId { get; private set; }
        public string CallerDeviceId { get; private set; }
        public Int32 TargetId { get; private set; }

        public CallReqPackage(byte[] messageBytes) : base(messageBytes)
        {
            int offset = base.GetLength();
            string newValue;

            CallerUserId = BitConverter.ToInt32(messageBytes, offset);
            offset += sizeof(Int32);
            offset = ReadTextBytes(messageBytes, offset, out newValue);
            CallerDeviceId = newValue;
            TargetId = BitConverter.ToInt32(messageBytes, offset);
            offset += sizeof(Int32);
        }

        public CallReqPackage(Int32 callerId, string callerDeviceId, Int32 targetId) : base(MessageTypes.CallReq)
        {
            CallerUserId = callerId;
            CallerDeviceId = callerDeviceId;
            TargetId = targetId;
        }

        public override int GetLength()
        {
            return base.GetLength() + GetLocalContentLength();
        }

        protected new int GetLocalContentLength()
        {
            return sizeof(Int32) + 1 + CallerDeviceId.Length + sizeof(Int32);
        }

        public override void CopyContent(byte[] outBuffer, int offset)
        {
            base.CopyContent(outBuffer, 0);

            offset += base.GetLength();

            offset = WriteFixedBytes(outBuffer, offset, BitConverter.GetBytes(CallerUserId));

            offset = WriteTextBytes(outBuffer, offset, CallerDeviceId);

            offset = WriteFixedBytes(outBuffer, offset, BitConverter.GetBytes(TargetId));
        }
    }
}
