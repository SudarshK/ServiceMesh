using ServiceMesh.Services.ShoppingCartAPI.Models;
using ServiceMesh.Services.ShoppingCartAPI.Models.DTO;

namespace ServiceMesh.Services.ShoppingCartAPI.Service.IServices
{
    public interface ICouponService
    {
        Task<CouponDto> GetCoupon(string couponCode);
    }
}
