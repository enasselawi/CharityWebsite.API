using CharityWebsite.Core.Data;
using CharityWebsite.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityWebsite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactMessageController : ControllerBase
    {
        private readonly IContactMessageService _service;

        public ContactMessageController(IContactMessageService service)
        {
            _service = service;
        }


        [HttpPost("AddContactMessage")]
        public IActionResult AddContactMessage([FromBody] ContactMessage message)
        {
            _service.AddContactMessage(message);
            return Ok("Message added successfully");
        }

        [HttpGet("GetAllContactMessages")]
        public ActionResult<List<ContactMessage>> GetAllContactMessages()
        {
            var messages = _service.GetAllContactMessages();
            return Ok(messages);
        }
    }
}
