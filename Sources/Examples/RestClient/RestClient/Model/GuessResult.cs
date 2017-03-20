using System.Runtime.Serialization;

namespace RestClient
{
    [DataContract]
    public class GuessResult
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "answer")]
        public string Answer { get; set; }

        [DataMember(Name = "guesses")]
        public string Guesses { get; set; }
    }
}
