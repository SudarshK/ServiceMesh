using ServiceMesh.Services.Web.Models.DTO;
using ServiceMesh.Web.Models;

namespace ServiceMesh.Web.Service.IService
{
    public interface IOrderService
    {
        Task<ResponseDto?>CreateOrder(CartDto cartDto);
    }
}
