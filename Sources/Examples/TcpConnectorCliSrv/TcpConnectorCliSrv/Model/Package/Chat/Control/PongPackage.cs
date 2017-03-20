using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xPhoneShared.SocketStream.Package
{
    class PongPackage : Package
    {
        #region Ctors

        public PongPackage(byte[] messageBytes) : base(messageBytes)
        {
            int offset = base.GetLength();
        }

        public PongPackage() : base(MessageTypes.Pong)
        {
        }

        #endregion
    }
}
