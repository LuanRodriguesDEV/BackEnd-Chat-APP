using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRTest.Model;
using SignalRTest.Services;

namespace SignalRTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserServices _services;

        public UserController(UserServices services)
        {
            _services = services;
        }
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            var create = await _services.CreateUser(user);
            return create != null ? Ok(create) : BadRequest();
        }
        [HttpGet("{email}/{password}")]
        public async Task<ActionResult<User>> Login(string email,string password)
        {
            var create = await _services.Login(email,password);
            return create != null ? Ok(create) : BadRequest();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var create = await _services.GetAllUsers();
            return create != null ? Ok(create) : BadRequest();
        }
    }
}
