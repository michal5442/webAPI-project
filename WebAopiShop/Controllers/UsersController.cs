using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;
using WebAopiShop;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShop.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        string filePath = "users.txt";
        IUserService service;

        public UsersController(IUserService service)
        {
            this.service = service;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };

        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            User user = await service.GetUserById(id);
            if (user == null)
            {
                return NoContent();
            }
            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login([FromBody] User val)
        {
            User user = await service.LogIn(val);
            if (user == null)
            {
                return NoContent();
            }
            return Ok(user);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register([FromBody] User val)
        {
            User user = await service.AddUser(val);
            if (user == null)
            {
                return BadRequest("Password too weak");
            }
            return CreatedAtAction(nameof(Get), new {user.UserId},user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User value)
        {
           bool success = await service.UpdateUser(value,id);
           if(!success)
            {
                return BadRequest("Password too weak");
            }
           return Ok(value);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
