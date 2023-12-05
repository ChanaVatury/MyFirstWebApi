using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Servicies;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductServices productServices;
        IMapper mapper;

        public ProductController(IProductServices _productServices, IMapper _mapper)
        {
            productServices = _productServices;
            mapper = _mapper;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get(string? name,  int? minPrice,
             int? maxPrice, [FromQuery] int?[] categoryIds)
        {
            IEnumerable<Product> allProducts = await productServices.getAllProduct(name,minPrice,maxPrice,categoryIds);
            IEnumerable<ProductDTO> allProductsDTO=mapper.Map<IEnumerable<Product>, IEnumerable< ProductDTO >> (allProducts);
            if (allProductsDTO.Count() == 0)
                return NoContent();
            return Ok(allProductsDTO);
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
