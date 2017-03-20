using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RestService
{
    [DataContract]
    public class GuessRequest
    {
        [DataMember(Name = "token")]
        public string Token { get; set; }

        [DataMember(Name = "value")]
        public int Value { get; set; }

        public GuessRequest()
        {
            Token = "";
            Value = 0;
        }

        public GuessRequest(string token, int value)
        {
            Token = token;
            Value = value;
        }
    }
}