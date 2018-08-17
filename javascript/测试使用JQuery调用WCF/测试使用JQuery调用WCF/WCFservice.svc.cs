using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace 测试使用JQuery调用WCF
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WCFservice
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public string InsertRow(int id, string title, string content)
        {
            return string.Format("您输入的标题是：{0}\n\n您输入的内容是：{1}\n\n此文章的id是：{2}", title, content, id.ToString());
        }
    }
}