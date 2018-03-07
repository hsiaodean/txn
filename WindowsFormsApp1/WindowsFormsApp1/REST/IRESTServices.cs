using System.ServiceModel;
using System.ServiceModel.Web;

namespace ConsoleWCFService.REST
{
    [ServiceContract(Name = "RESTServices")]
    public interface IRESTServices
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = Routing.WriteRoute, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string Write(string msg);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = Routing.queryPosition, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string QueryPosition();
    }
}
