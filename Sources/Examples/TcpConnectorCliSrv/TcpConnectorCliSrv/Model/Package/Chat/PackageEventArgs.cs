using System;
using System.Collections.Generic;
using System.Text;

namespace xPhoneShared.SocketStream.Package
{
    public class PackageEventArgs : EventArgs
    {
        public Package Package { get; set; }

        public PackageEventArgs(Package package)
        {
            Package = package;
        }
    }
}
