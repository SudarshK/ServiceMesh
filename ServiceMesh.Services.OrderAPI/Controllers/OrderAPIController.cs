using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceMesh.Services.OrderAPI.Data;
using ServiceMesh.Services.OrderAPI.Models;
using ServiceMesh.Services.OrderAPI.Models.DTO;
using ServiceMesh.Services.OrderAPI.Service.IServices;
using ServiceMesh.Services.OrderAPI.Utility;

namespace ServiceMesh.Services.OrderAPI.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private readonly AppDbContext _db;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public OrderAPIController(AppDbContext db,IProductService productService,IMapper mapper)
        {
            _db = db;
            this._response = new ResponseDto();
            _productService = productService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("CreateOrder")]
        public async Task<ResponseDto> CreateOrder([FromBody] CartDto cartDto)
        {
            try
            {
                OrderHeaderDto orderHeaderDto = _mapper.Map<OrderHeaderDto>(cartDto.CartHeader);
                orderHeaderDto.OrderTime= DateTime.Now;
                orderHeaderDto.Status= SD.Status_Pending;
                orderHeaderDto.OrderDetails = _mapper.Map<IEnumerable<OrderDetailsDto>>(cartDto.CartDetails);

                OrderHeader orderCreated = _db.OrderHeaders.Add(_mapper.Map<OrderHeader>(orderHeaderDto)).Entity;
                await _db.SaveChangesAsync();

                orderHeaderDto.OrderHeaderId = orderCreated.OrderHeaderId;
                _response.Result = orderHeaderDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
