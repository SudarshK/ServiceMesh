using ServiceMesh.Web.Utility;
using static ServiceMesh.Web.Utility.SD;

namespace ServiceMesh.Web.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url {  get; set; }
        public object Data {  get; set; }
        public string AccessToken {  get; set; }
    }
}
