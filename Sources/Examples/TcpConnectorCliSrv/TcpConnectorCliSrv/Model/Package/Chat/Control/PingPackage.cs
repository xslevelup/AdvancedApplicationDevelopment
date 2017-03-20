using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xPhoneShared.SocketStream.Package
{
    class PingPackage : Package
    {
        #region Ctors

        public PingPackage(byte[] messageBytes) : base(messageBytes)
        {
            int offset = base.GetLength();
        }

        public PingPackage() : base(MessageTypes.Ping)
        {
        }

        #endregion
    }
}
