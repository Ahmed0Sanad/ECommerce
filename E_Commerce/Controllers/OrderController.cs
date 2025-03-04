using AutoMapper;
using E_Commerce.DTO;
using E_Commerce.Errors;
using ECommerce.Core.Entity.OrderEntitys;
using ECommerce.Core.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {
            var address = _mapper.Map<AddressDto, Address>(orderDto.ShippingAddress);
            var order = await _orderService.CreateOrderAsync(orderDto.BuyerEmail, orderDto.DeliveryMethodId, orderDto.BasketId, address);
            if (order == null) { return BadRequest(new ApiResponse(401)); }
            return Ok(order);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersForUser(string BuyerEmail)
        {
            var Orders = await _orderService.GetOrdersAsync(BuyerEmail);
            if (Orders is null)
            {
                return BadRequest(new ApiResponse(404));
            }
            return Ok(Orders);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id , string buyerEmail)
        {
            var order = await _orderService.GetOrderByIdAsync(id, buyerEmail);
            if (order == null) { return BadRequest(new ApiResponse(404)); }
            return Ok(order);
            
        }
    }
}
