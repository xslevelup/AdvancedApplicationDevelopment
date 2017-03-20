using System;
using System.Collections.Generic;
using System.Text;

namespace xPhoneShared.SocketStream.Package
{
    public class RingReqPackage : ContentPackage
    {
        public enum RingStates : byte
        {
            Stop = 0,
            Start = 1
        }

        public RingStates State { get; set; }
        public string DeviceId { get; private set; }
        public int UserId { get; private set; }

        public RingReqPackage(byte[] messageBytes) : base(messageBytes)
        {
            int offset = base.GetLength();

            State = (RingStates)messageBytes[offset];
            offset += 1;

            string strValue;
            offset = ReadTextBytes(messageBytes, offset, out strValue);
            DeviceId = strValue;

            offset = ReadTextBytes(messageBytes, offset, out strValue);
            UserId = Convert.ToInt32(strValue);
        }

        public RingReqPackage(RingStates state, string deviceId, int userId) : base(MessageTypes.RingReq)
        {
            State = state;
            DeviceId = deviceId;
            UserId = userId;
        }

        public override int GetLength()
        {
            return base.GetLength() + GetLocalContentLength();
        }

        protected new int GetLocalContentLength()
        {
            return 1 
                + 1 + Encoding.UTF8.GetByteCount(DeviceId)
                + 1 + sizeof(int);
        }

        public override void CopyContent(byte[] outBuffer, int offset)
        {
            base.CopyContent(outBuffer, offset);

            offset += base.GetLength();
            outBuffer[offset] = (byte)State;
            offset += 1;
            offset = WriteTextBytes(outBuffer, offset, DeviceId);
            offset = WriteFixedBytes(outBuffer, offset, BitConverter.GetBytes(UserId));
        }

    }
}
