using AutoMapper;
using DTO;
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
        IMapper mapper;

        public CategoryController(ICategoryServices _categoryServices ,IMapper _mapper)
        {
            categoryServices = _categoryServices;
            mapper = _mapper;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {

                IEnumerable<Category> allCategory = await categoryServices.getAllCategory();
                IEnumerable<CategoryDTO> CategoryListDTO = mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(allCategory);
                if (CategoryListDTO.Count() == 0)
                    return NoContent();
                return Ok(CategoryListDTO);
        
        }

    }
}
