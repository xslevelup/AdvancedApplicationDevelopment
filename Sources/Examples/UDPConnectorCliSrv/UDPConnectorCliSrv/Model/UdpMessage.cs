using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDPConnector
{
    class UdpMessage
    {
        public enum Types
        {
            NA, 
            close,
            register,
            message
        }

        public string Text { get; private set; }
        public Types Type { get; private set; }
        public string[] Parameters { get; private set; }

        public UdpMessage()
        {
            Text = string.Empty;
            Type = Types.NA;
            Parameters = null;
        }

        public UdpMessage(byte[] bytes)
        {
            Text = Encoding.ASCII.GetString(bytes).Trim();
            Parse();
        }

        private void Parse()
        {
            Parameters = null;
            Type = Types.NA;

            if (string.Compare(Text.ToLower(), "close") == 0)
            {
                Type = Types.close;
            }

            if (Text.StartsWith("reg(") && Text.EndsWith(")"))
            {
                Parameters = Text.Substring(4, Text.Length - 5).Split(',');
                Type = Types.register;
            }

            if (Text.StartsWith("msg(") && Text.EndsWith(")"))
            {
                Parameters = Text.Substring(4, Text.Length - 5).Split(',');
                Type = Types.message;
            }
        }

    }
}
