using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRestService" in both code and config file together.
    [ServiceContract]
    public interface IRestService
    {

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "/register",
            ResponseFormat = WebMessageFormat.Json
            )]
        RegisterResult RegisterGame();

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/guess",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json
            )]
        GuessResult MakeGuess(GuessRequest req);

    }

}
