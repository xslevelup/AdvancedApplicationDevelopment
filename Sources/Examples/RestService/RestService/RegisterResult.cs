using System.Runtime.Serialization;

namespace RestService
{
    [DataContract]
    public class RegisterResult
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "token")]
        public string Token { get; set; }

        public RegisterResult()
        {
            Status = "";
            Token = "";
        }

        public RegisterResult(string status, string token)
        {
            Status = status;
            Token = token;
        }
    }
}
