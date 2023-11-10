using Entities;
using Microsoft.AspNetCore.Mvc;
using Servicies;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Zxcvbn;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        IUserServicies userServices;

        public UsersController(IUserServicies _userServices)
        {
            userServices = _userServices;
        }
        [HttpPost("check")]
        public int Check([FromBody] string password)
        {
            if (password != "")
            {
                var result = Zxcvbn.Core.EvaluatePassword(password);
                return result.Score;
            }
            return -1;

        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<Users>> Get([FromQuery] string userName, [FromQuery] string code)
        {
            Users user = await userServices.getUserByPasswordAndUserName(code, userName);
            if (user == null)
                 return NoContent();
            return Ok(user);
        }
        // GET api/<UserController>/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<IEnumerable<Users>>> Get([FromQuery] int id)
        //{
        //    Users user = await userServices.getUserById(id);
        //    if (user == null)
        //        return NoContent();
        //    return Ok(user);
        //}

        //POST api/<UserController>
        [HttpPost("")]//
        public async Task<ActionResult> Post([FromBody] Users user)
        {
            
                Users newUser = await userServices.addUser(user);

            return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
               
           
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<Users> Put(int id, [FromBody] Users userToUpdate)
        {
            Users user = await userServices.updateUser(id, userToUpdate);
            return user;
        }


        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
