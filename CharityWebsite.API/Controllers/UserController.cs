using CharityWebsite.Core.Data;
using CharityWebsite.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityWebsite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Endpoint to View Profile
        [HttpGet("ViewUserProfile/{id}")]
        public ActionResult<Userr> ViewUserProfile(int id)
        {
            var user = _userService.GetUserProfile(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            return Ok(user);
        }

        // Endpoint to Update Profile
        [HttpPut("UpdateUserProfile")]
        public IActionResult UpdateUserProfile([FromBody] Userr user)
        {
            _userService.UpdateUserProfile(user);
            return Ok();
        }
    }
}
