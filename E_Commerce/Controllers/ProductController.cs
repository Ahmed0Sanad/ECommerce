using AutoMapper;
using E_Commerce.DTO;
using ECommerce.Core.Entity;
using ECommerce.Core.Repository.Contract;
using ECommerce.Core.Specifications;
using ECommerce.Core.Specifications.ProductSpecifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IMapper _mapper;

        public ProductController(IGenericRepository<Product> ProductRepo,IMapper mapper)
        {
            _productRepo = ProductRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Getall() 
        {
            var spec = new ProductWithBrandAndCategory();
            var result =await _productRepo.GetAllSpecAsync(spec);
            return Ok(_mapper.Map< IEnumerable<Product>, IEnumerable<ProductDTO> >(result));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var spec = new ProductWithBrandAndCategory(id);
            var product = await _productRepo.GetSpecAsync(id,spec);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<Product,ProductDTO>(product));
        }

    }
}
