using ServiceMesh.Services.Web.Models.DTO;
using ServiceMesh.Web.Models;

namespace ServiceMesh.Web.Service.IService
{
    public interface ICartService
    {
        Task<ResponseDto?>GetCartByUserIdAsync(string userId);
        Task<ResponseDto?>UpsertCartAsync(CartDto cartDto);
        Task<ResponseDto?>RemoveFromCartAsync(int cartdetailsId);
        Task<ResponseDto?>ApplyCouponAsync(CartDto couponDto);
    }
}
