using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Http.HttpResults;
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
        IMapper mapper;
        private ILogger<UsersController> logger;
        public UsersController(IUserServicies _userServices,IMapper _mapper, ILogger<UsersController> _logger)
        {
            userServices = _userServices;
            mapper = _mapper;
            logger = _logger;
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

        [Route("login")]
        // GET: api/<UserController>
        [HttpPost]
        public async Task<ActionResult<Users>> Get([FromBody] UserDTOLogin userDTOLogin)
        {
                string code = userDTOLogin.Passwordd;
                string userName = userDTOLogin.Email;
                Users user = await userServices.getUserByPasswordAndUserName(code, userName);
                if (user == null)            
                    return NotFound();
              return Ok(user);  
        }

        //POST api/<UserController>
        [HttpPost("")]//
        public async Task<ActionResult> Post([FromBody] UserDTO userDTO)
        {
            Users newUser = mapper.Map<UserDTO, Users>(userDTO);
            Users newU=await userServices.addUser(newUser);
            if(newU!=null)
                return CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUser);
            return NoContent();   
           
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<UserDTO> Put(int id, [FromBody] UserDTO userDTO)
        {
            Users newUser = mapper.Map<UserDTO, Users>(userDTO);
            await userServices.updateUser(id, newUser);
            return mapper.Map<Users,UserDTO >(newUser);
        }


        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
