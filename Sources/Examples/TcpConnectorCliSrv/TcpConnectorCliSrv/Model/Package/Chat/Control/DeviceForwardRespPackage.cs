using System;
using System.Collections.Generic;
using System.Text;

namespace xPhoneShared.SocketStream.Package
{
    class DeviceForwardRespPackage : DeviceStatePackage
    {
        public DeviceForwardRespPackage(byte[] messageBytes) : base(messageBytes) { }

        public DeviceForwardRespPackage(byte state, string senderDeviceId) : base(MessageTypes.DeviceForwardResp, state, senderDeviceId) { }
    }
}
