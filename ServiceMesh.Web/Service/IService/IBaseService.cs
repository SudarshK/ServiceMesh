using ServiceMesh.Web.Models;

namespace ServiceMesh.Web.Service.IService
{
    public interface IBaseService
    {
       Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true);
    }
}
