using System;
using System.Collections.Generic;
using System.Text;

namespace xPhoneShared.SocketStream
{
    public abstract class PackageBase
    {
        public static byte Delimiter { get; set; }

        #region Ctors

        public PackageBase()
        { }

        public PackageBase(byte[] packetBytes) : this(packetBytes, 0)
        { }

        public PackageBase(byte[] packetBytes, int offset)
        {
            SetupFromByteArray(packetBytes, offset);
        }

        #endregion

        public virtual byte[] GetBytes()
        {
            byte[] buffer = new byte[GetLength() + 1];

            CopyContent(buffer, 0);

            buffer[buffer.Length - 1] = Delimiter;

            return buffer;
        }

        #region Abstract methods

        public abstract int GetLength();

        public abstract void SetupFromByteArray(byte[] packetBytes, int offset);

        public abstract void CopyContent(byte[] buffer, int offset);

        #endregion
    }
}
