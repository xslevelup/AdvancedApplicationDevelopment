using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testWCFclient
{
    class UserWithName : testWCFclient.LoginServiceReference.User
    {
        public UserWithName(testWCFclient.LoginServiceReference.User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Code = user.Code;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }
    }
}
