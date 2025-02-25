using AutoMapper;
using E_Commerce.DTO;
using E_Commerce.Errors;
using ECommerce.Core.Entity.rides;
using ECommerce.Core.Repository.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepo;
        private readonly IMapper mapper;

        public BasketController(IBasketRepository BasketRepository,IMapper mapper)
        {
            _basketRepo = BasketRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasket(string id)
        {
            var basket = await _basketRepo.GetCustomerBasket(id);
            if (basket == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok(basket);
        }
        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> SetBasket(CustomerBasketDTO Customerbasket)
        {
            var mappedBasket = mapper.Map<CustomerBasketDTO,CustomerBasket>(Customerbasket);
            var basket = await _basketRepo.SetCustomerBasket(mappedBasket);
            if (basket == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok(basket);
        }
        [HttpDelete]
        public async Task DeleteBasket(string id)
        {
            await _basketRepo.DeleteCustomerBasket(id);

        }
    }
}
