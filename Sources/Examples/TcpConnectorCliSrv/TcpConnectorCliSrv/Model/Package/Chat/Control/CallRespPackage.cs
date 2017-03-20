using System;
using System.Collections.Generic;
using System.Text;

namespace xPhoneShared.SocketStream.Package
{
    class CallRespPackage : ContentPackage
    {
        public bool IsSuccessful { get; private set; }
        public Int32 SessionId { get; private set; }

        public CallRespPackage(byte[] messageBytes) : base(messageBytes)
        {
            int offset = base.GetLength();
            IsSuccessful = messageBytes[offset] > 0;
            offset += 1;
            SessionId = BitConverter.ToInt32(messageBytes, offset);
            offset += sizeof(Int32);
        }

        public CallRespPackage(bool isSuccessful, Int32 sessionId) : base(MessageTypes.CallResp)
        {
            IsSuccessful = isSuccessful;
            SessionId = sessionId;
            Console.Write("SessionId: {0}", sessionId);
        }

        public override int GetLength()
        {
            return base.GetLength() + GetLocalContentLength();
        }

        protected new int GetLocalContentLength()
        {
            return 1 + sizeof(Int32);
        }

        public override void CopyContent(byte[] outBuffer, int offset)
        {
            base.CopyContent(outBuffer, offset);

            offset += base.GetLength();
            outBuffer[offset] = (byte)(IsSuccessful ? 1 : 0);
            offset += 1;
            offset = WriteFixedBytes(outBuffer, offset, BitConverter.GetBytes(SessionId));
        }
    }
}
