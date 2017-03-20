using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RestService
{
    [DataContract]
    public class GuessResult
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "answer")]
        public string Answer { get; set; }

        [DataMember(Name = "guesses")]
        public int Guesses { get; set; }

        public GuessResult()
        {
            Status = "";
            Answer = "";
            Guesses = 0;
        }

        public GuessResult(string status, string answer, int guesses)
        {
            Status = status;
            Answer = answer;
            Guesses = guesses;
        }
    }
}
