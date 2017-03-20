using System;
using System.Collections.Generic;
using System.Text;

namespace xPhoneShared.SocketStream.Package
{
    class LoginRespPackage : Package
    {
        #region Ctors

        public LoginRespPackage(byte[] messageBytes) : base(messageBytes)
        {
            int offset = base.GetLength();
        }

        public LoginRespPackage() : base(MessageTypes.LoginResp)
        {
        }

        #endregion
    }
}
