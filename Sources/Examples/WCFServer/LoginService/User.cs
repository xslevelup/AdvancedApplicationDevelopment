using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace testWCFsrv
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Code { get; set; }

        public User(string firstName, string lastName, string code)
        {
            FirstName = firstName;
            LastName = lastName;
            Code = code;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }
    }
}
