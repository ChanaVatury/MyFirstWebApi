using Entities;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Servicies;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryServices categoryServices;

        public CategoryController(ICategoryServices _categoryServices)
        {
            categoryServices = _categoryServices;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            IEnumerable<Category> allCategory = await categoryServices.getAllCategory();
            return allCategory;
        }

    }
}
