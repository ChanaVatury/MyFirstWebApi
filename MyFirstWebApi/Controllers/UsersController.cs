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
            //Change object name from Users to User (in entities)...
            //Change the "code" variable name- to password.
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
            //Check if newUser== null return BadRequest()
            return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
           
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        //Function should return Task<ActionResult<User>>>
        public async Task<Users> Put(int id, [FromBody] Users userToUpdate)
        {
            Users user = await userServices.updateUser(id, userToUpdate);
            //Check if user== null return BadRequest()
            //else return OK(user) 
            return user;
        }

        //Clean code -Remove unnecessary lines of code.
        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
