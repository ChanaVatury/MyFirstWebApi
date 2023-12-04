using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Servicies;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServicies orderServicies;
        private readonly IMapper mapper;

        public OrderController(IOrderServicies _orderServicies, IMapper _mapper)
        {
            orderServicies = _orderServicies;
            mapper = _mapper;
        }

        // GET: api/<OrderController>
    

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] OrderDTO order)
        {
            Order ord = mapper.Map<OrderDTO, Order>(order);
            Order newOrder = await orderServicies.addOrder(ord);
            if (newOrder == null)
                return BadRequest();
            OrderDTO o= mapper.Map<Order,OrderDTO >(newOrder);
            return CreatedAtAction(nameof(Get), new { id = o.OrderId }, o);
        }

      
    }
}