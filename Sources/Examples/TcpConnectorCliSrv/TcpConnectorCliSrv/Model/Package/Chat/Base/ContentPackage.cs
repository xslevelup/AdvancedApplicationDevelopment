using System;
using System.Text;

namespace xPhoneShared.SocketStream.Package
{
    public abstract class ContentPackage : Package
    {
        public ContentPackage(byte[] messageBytes) : base(messageBytes)
        {
        }

        public ContentPackage(MessageTypes type) : base(type)
        {
        }

        public override int GetLength()
        {
            return base.GetLength() + 2 + GetLocalContentLength();
        }

        protected new int GetLocalContentLength()
        {
            return 0;
        }

        public override void CopyContent(byte[] outBuffer, int offset)
        {
            base.CopyContent(outBuffer, offset);

            offset += base.GetLength();
            byte[] lengthBytes = BitConverter.GetBytes((UInt16)GetLength());
            if (BitConverter.IsLittleEndian)
                Array.Reverse(lengthBytes);
            Buffer.BlockCopy(lengthBytes, 0, outBuffer, offset, 2);
        }

        #region Write bytes

        protected int WriteTextBytes(byte[] buffer, int offset, string text)
        {
            byte[] tokenBytes = Encoding.UTF8.GetBytes(text);

            return WriteBytes(buffer, offset, tokenBytes);
        }

        protected int WriteFixedBytes(byte[] buffer, int offset, byte[] input)
        {
            Buffer.BlockCopy(input, 0, buffer, offset, input.Length);

            return offset + input.Length;
        }

        protected int WriteBytes(byte[] buffer, int offset, byte[] input)
        {
            buffer[offset] = (byte)input.Length;
            Buffer.BlockCopy(input, 0, buffer, offset + 1, input.Length);

            return offset + 1 + input.Length;
        }

        #endregion

        #region Read bytes

        protected int ReadTextBytes(byte[] buffer, int offset, out string text)
        {
            int length = buffer[offset];

            if (length > 0)
            {
                text = Encoding.UTF8.GetString(buffer, offset + 1, length);
            }
            else
            {
                text = string.Empty;
            }

            return offset + length + 1;
        }

        protected int ReadBytes(byte[] buffer, int offset, out byte[] outBuffer)
        {
            int length = buffer[offset];

            if (length > 0)
            {
                outBuffer = new byte[length];
                Buffer.BlockCopy(buffer, offset + 1, outBuffer, 0, length);
            }
            else
            {
                outBuffer = null;
            }

            return offset = length + 1;
        }

        #endregion

    }
}
