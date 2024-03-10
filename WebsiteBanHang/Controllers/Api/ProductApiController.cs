using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebsiteBanHang.Models;
using WebsiteBanHang.Repositories;

namespace WebsiteBanHang.Controllers.Api
{
    [Route("api/products")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductApiController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _productRepository.GetAllAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            try
            {
                await _productRepository.AddAsync(product);
                return Ok();
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
