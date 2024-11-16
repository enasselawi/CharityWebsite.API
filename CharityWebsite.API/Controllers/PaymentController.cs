using CharityWebsite.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityWebsite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _service;

        public PaymentController(IPaymentService service)
        {
            _service = service;
        }

        [HttpPost("PayForPost")]
        public IActionResult PayForPost(int userId, int charityId, decimal amount, long cardNumber, DateTime expiryDate, int cvv)
        {
            _service.PayForPost(userId, charityId, amount, cardNumber, expiryDate, cvv);
            return Ok("Payment completed successfully.");
        }
    }
}
