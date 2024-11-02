using CharityWebsite.Core.Data;
using CharityWebsite.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityWebsite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;

        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] Userr user)
        {
            if (user == null) return BadRequest("User data is missing");

            _registerService.Register(user);
            return Ok("User registered successfully");
        }
    }
}
