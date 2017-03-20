using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpConnectorCliSrv
{
    public class SocketCommunicationEventArgs
    {
        public byte[] Data { get; private set; }

        public SocketCommunicationEventArgs(byte[] data)
        {
            Data = data;
        }
    }
}
