using ServiceMesh.Services.Web.Models.DTO;
using ServiceMesh.Web.Models;
using ServiceMesh.Web.Service.IService;
using ServiceMesh.Web.Utility;

namespace ServiceMesh.Web.Service
{
    public class OrderService : IOrderService
    {
        private readonly IBaseService _baseService;

        public OrderService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateOrder(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDto,
                Url = SD.OrderAPIBase + "/api/order/CreateOrder"
            });
        }
 
    }
}
