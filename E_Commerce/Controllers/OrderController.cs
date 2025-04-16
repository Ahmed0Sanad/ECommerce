using AutoMapper;
using E_Commerce.DTO;
using E_Commerce.Errors;
using ECommerce.Core.Entity.OrderEntitys;
using ECommerce.Core.Services.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
//using StackExchange.Redis;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        public async Task<ActionResult<string>> CreateOrder(OrderDto orderDto)
        {
            var BuyerEmail = User.FindFirstValue(ClaimTypes.Email);
           
            var address = _mapper.Map<AddressDto, Address>(orderDto.ShippingAddress);
            var order = await _orderService.CreateOrderAsync(BuyerEmail, orderDto.DeliveryMethodId, orderDto.BasketId, address);
            if (order == null) { return BadRequest(new ApiResponse(401)); }

            return Ok(order);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderToReturnDto>>> GetOrdersForUser()
        {
            var BuyerEmail = User.FindFirstValue(ClaimTypes.Email);
            var Orders = await _orderService.GetOrdersAsync(BuyerEmail);
            if (Orders is null)
            {
                return BadRequest(new ApiResponse(404));
            }
            var ordersToRetrun = _mapper.Map<IEnumerable<Order>, IEnumerable< OrderToReturnDto>>(Orders);

            return Ok(ordersToRetrun);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderToReturnDto>> GetOrderById(int id )
        {
            var BuyerEmail = User.FindFirstValue(ClaimTypes.Email);

            var order = await _orderService.GetOrderByIdAsync(id, BuyerEmail);
            if (order == null) { return BadRequest(new ApiResponse(404)); }
            var orderToRetrun = _mapper.Map<Order, OrderToReturnDto>(order);

            return Ok(orderToRetrun);
            
        }
        [HttpGet("delivery")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<DeliveryMethod>>> GetAllDeliveryMethod()
        {
            var reslut = await _orderService.GetDeliveryMethodAsync();
            return Ok(reslut);
        }
    }
}
