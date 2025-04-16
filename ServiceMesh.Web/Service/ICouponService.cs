using ServiceMesh.Web.Models;

namespace ServiceMesh.Web.Service
{
    public interface ICouponService
    {
        Task<ResponseDto?>GetCouponAsync(string couponCode);
        Task<ResponseDto?>GetAllCouponAsync();
        Task<ResponseDto?>GetCouponByIdAsync(int id);
        Task<ResponseDto?>CreateCouponAsync(CouponDto couponDto);
        Task<ResponseDto?>UpdateCouponAsync(CouponDto couponDto);
        Task<ResponseDto?>DeleteCouponAsync(int id);
    }
}
