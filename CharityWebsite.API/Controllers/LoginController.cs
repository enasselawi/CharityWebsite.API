using CharityWebsite.Core.Data;
using CharityWebsite.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityWebsite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Auth([FromBody] Userr userr)
        {
            var token = _loginService.Auth(userr);
            if (token == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(token);
            }


        }
    }
}
