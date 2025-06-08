using DeliverySystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DeliverySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService product;

        public ProductController(IProductService product)
        {
            this.product = product;
        }
        [HttpGet("AllProduct")]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await product.GetAllProductsAsync();
            return Ok(result);
        }
    }
}
