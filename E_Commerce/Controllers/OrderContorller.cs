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
    public class OrderContorller : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderContorller(IOrderService orderService,IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        
        [HttpPost]
        public async Task<ActionResult<Order>> AddOrder(OrderDto orderDto)
        {
            var address = _mapper.Map<AddressDto,Address>(orderDto.ShippingAddress);
            var order = await _orderService.CreateOrderAsync(orderDto.BuyerEmail, orderDto.DeliveryMethodId, orderDto.BasketId, address);
            if (order == null) { return BadRequest(new ApiResponse(401)); }
            return Ok(order);
        }
    }
}
