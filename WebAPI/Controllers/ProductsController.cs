using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;
using WebAPI.Entities.Dtos;
using WebAPI.Services.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            Product product = await _productService.CreateProductAsync(createProductDto);
            return Ok(product);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllProduct()
        {
            ICollection<Product> products = await _productService.GetAllAsync(include:p => p.Include(opt => opt.AttiributeValues!));
            return Ok(products);
        }
    }
}
