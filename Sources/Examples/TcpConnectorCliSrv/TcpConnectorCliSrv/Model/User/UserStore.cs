using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpConnectorCliSrv.Model.User
{
    class UserStore
    {
        public List<User> UserList { get; set; }

        #region API

        public UserStore(string fileName)
        {
            UserList = new List<User>();

            LoadFile(fileName);
        }

        public bool AuthenticateUser(string userName, string password)
        {
            User user = UserList.FirstOrDefault(x => string.Compare(x.UserName, userName) == 0);

            if (user != null)
                return string.Compare(user.Password, password) == 0;

            return false;
        }

        #endregion

        private void LoadFile(string fileName)
        {
            string content = File.ReadAllText(fileName);
            string[] lines = content.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            string[] values;

            foreach(string line in lines)
            {
                values = line.Split(';');
                UserList.Add(new User(values[0], values[1], values[2]));
            }
        }
        
    }
}
