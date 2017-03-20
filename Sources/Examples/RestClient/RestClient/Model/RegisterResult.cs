using System.Runtime.Serialization;

namespace RestClient
{
    [DataContract]
    public class RegisterResult
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "token")]
        public string Token { get; set; }
    }
}
