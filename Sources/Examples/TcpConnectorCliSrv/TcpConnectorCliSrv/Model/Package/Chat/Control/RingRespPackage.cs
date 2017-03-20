using System;
using System.Collections.Generic;
using System.Text;

namespace xPhoneShared.SocketStream.Package
{
    class RingRespPackage : DeviceStatePackage
    {
        public enum RingResponseTypes : byte {
            Accept = 0,
            Reject = 1
        }

        public new RingResponseTypes State
        {
            get
            {
                return (RingResponseTypes)base.State;
            }

            private set
            {
                base.State = (byte)value;
            }
        }

        public RingRespPackage(byte[] messageBytes) : base(messageBytes) { }

        public RingRespPackage(RingResponseTypes state, string senderDeviceId) : base(MessageTypes.RingResp, (byte)state, senderDeviceId) { }
    }
}
