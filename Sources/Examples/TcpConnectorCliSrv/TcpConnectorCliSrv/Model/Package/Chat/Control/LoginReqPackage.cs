using System;
using System.Collections.Generic;
using System.Text;

namespace xPhoneShared.SocketStream.Package
{
    class LoginReqPackage : ContentPackage
    {
        public string DeviceId { get; private set; }
        public string RefreshToken { get; private set; }
        public string AccessToken { get; private set; }

        #region Ctors

        public LoginReqPackage(byte[] messageBytes) : base(messageBytes)
        {
            int offset = base.GetLength();
            string newValue;
            offset = ReadTextBytes(messageBytes, offset, out newValue);
            RefreshToken = newValue;
            offset = ReadTextBytes(messageBytes, offset, out newValue);
            AccessToken = newValue;
        }

        public LoginReqPackage(string deviceId, string refreshToken, string accessToken) : base(MessageTypes.LoginReq)
        {
            DeviceId = deviceId;
            RefreshToken = refreshToken;
            AccessToken = accessToken;
        }

        #endregion

        public override int GetLength()
        {
            return base.GetLength() + GetLocalContentLength();
        }

        protected new int GetLocalContentLength()
        {
            return 1 + Encoding.UTF8.GetByteCount(DeviceId) 
                + 1 + Encoding.UTF8.GetByteCount(RefreshToken) 
                + 1 + Encoding.UTF8.GetByteCount(AccessToken);
        }

        public override void CopyContent(byte[] outBuffer, int offset)
        {
            base.CopyContent(outBuffer, 0);

            offset += base.GetLength();
            offset = WriteTextBytes(outBuffer, offset, DeviceId);
            offset = WriteTextBytes(outBuffer, offset, RefreshToken);
            offset = WriteTextBytes(outBuffer, offset, AccessToken);
        }

    }
}
