using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UDPConnector
{
    class Client
    {
        public string Id { get; private set; }
        public IPEndPoint Endpoint { get; private set; }

        public Client(string id, IPEndPoint endpoint)
        {
            Id = id;
            Endpoint = endpoint;
        }

    }
}
