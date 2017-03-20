using System;
using System.Collections.Generic;
using System.Text;

namespace xPhoneShared.SocketStream.Package
{
    class StatePackage : Package
    {
        public virtual byte State { get; private set; }

        public StatePackage(byte[] messageBytes) : base(messageBytes)
        {
            int offset = base.GetLength();
            State = messageBytes[offset];
        }

        public StatePackage(MessageTypes type, byte state) : base(type)
        {
            State = state;
        }

        public override int GetLength()
        {
            return base.GetLength() + GetLocalContentLength();
        }

        protected new int GetLocalContentLength()
        {
            return 1;
        }

        public override void CopyContent(byte[] outBuffer, int offset)
        {
            base.CopyContent(outBuffer, offset);

            offset += base.GetLength();
            outBuffer[offset] = State;
        }

    }
}
