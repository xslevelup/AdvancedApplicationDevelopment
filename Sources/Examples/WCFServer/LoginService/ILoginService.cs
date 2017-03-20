using System.Collections.Generic;
using System.ServiceModel;

namespace testWCFsrv
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ILoginService
    {

        [OperationContract]
        string GetData();

        [OperationContract]
        List<User> GetUsers();
    }

}
