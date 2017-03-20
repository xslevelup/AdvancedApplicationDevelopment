using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpConnectorCliSrv.Model.User
{
    class User
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }

        public User(string firstname, string lastName, string code)
        {
            FirstName = firstname;
            LastName = lastName;
            UserName = string.Format("{0}{1}", firstname.ToLower().Substring(0, 1), lastName.ToLower());
            Password = code;
        }

    }
}
