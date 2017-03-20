using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;

namespace testWCFsrv
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : ILoginService
    {
        public string GetData()
        {
            if (UserStorage.UserId == null)
                UserStorage.UserId = "12345";

            return File.ReadAllText(@"D:\Tomi\Repos\LevelUp\Session01\Ex04\codes.json");
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            string content = File.ReadAllText(@"D:\Tomi\Repos\LevelUp\Session01\Ex04\codes.json");

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<User>));

            MemoryStream stringStream = new MemoryStream(Encoding.UTF8.GetBytes(content ?? ""));
            users = (List<User>)serializer.ReadObject(stringStream);

            Thread.Sleep(5000);

            return users;
            
        }
    }
}
