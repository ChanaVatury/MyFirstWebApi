using Entities;
using Microsoft.AspNetCore.Mvc;
using Servicies;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductServices productServices;

        public ProductController(IProductServices _productServices)
        {
            productServices = _productServices;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IEnumerable<Product>> Get([FromQuery]string? name, [FromQuery] int? minPrice,
            [FromQuery] int? maxPrice, [FromQuery] int?[] categoryIds)
        {
            IEnumerable<Product> allProducts = await productServices.getAllProduct(name,minPrice,maxPrice,categoryIds);
            return allProducts;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Product>> Get(int id)
        {
            IEnumerable<Product> allProducts = await productServices.getProductByCategory(id);
            return allProducts;
        }

       
    }
}
