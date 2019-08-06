

using Microsoft.AspNetCore.Mvc;
using Shop.Web.Data;

namespace Shop.Web.Controllers.API
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(this.productRepository.GetAll());
        }
    }
}
