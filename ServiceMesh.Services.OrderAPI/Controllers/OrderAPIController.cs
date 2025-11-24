using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceMesh.MessageBus;
using ServiceMesh.Services.OrderAPI.Data;
using ServiceMesh.Services.OrderAPI.Models;
using ServiceMesh.Services.OrderAPI.Models.Dto;
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
        private readonly IMessageBus _messageBus;
        private readonly IConfiguration _configuration;

        public OrderAPIController(AppDbContext db,IProductService productService,IMapper mapper, IMessageBus messageBus,IConfiguration configuration)
        {
            _db = db;
            this._response = new ResponseDto();
            _productService = productService;
            _mapper = mapper;
            _messageBus = messageBus;
            _configuration = configuration;
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
                RewardsDto rewardsDto = new()
                {
                    OrderId = orderCreated.OrderHeaderId,
                    RewardsActivity = Convert.ToInt32(orderHeaderDto.OrderTotal),
                    UserId = orderHeaderDto.UserId
                };
                string topicName = _configuration.GetValue<string>("TopicAndQueueNames:OrderCreatedTopic");
                await _messageBus.PublishMessage(rewardsDto, topicName);
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
