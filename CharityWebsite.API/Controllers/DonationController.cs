using CharityWebsite.Core.Data;
using CharityWebsite.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityWebsite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private readonly IDonationService _donationService;

        public DonationController(IDonationService donationService)
        {
            _donationService = donationService;
        }
        [HttpPost]
        public IActionResult Donate([FromBody] DonationRequest request)
        {
            _donationService.Donate(request.UserID, request.CharityID, request.Amount, request.CardNumber, request.ExpiryDate, request.CVV);
            return Ok(new { message = "Donation processed successfully!" });
        }
        public class DonationRequest
        {
            public int UserID { get; set; }
            public int CharityID { get; set; }
            public decimal Amount { get; set; }
            public string CardNumber { get; set; }
            public DateTime ExpiryDate { get; set; }
            public string CVV { get; set; }
        }

        //    [HttpPost("make-donation")]
        //    public IActionResult MakeDonation([FromBody] DonationRequest donationRequest)
        //    {
        //        try
        //        {
        //            _donationService.MakeDonation(
        //                donationRequest.UserId,
        //                donationRequest.CharityId,
        //                donationRequest.Amount,
        //                donationRequest.CardNumber,
        //                donationRequest.ExpiryDate,
        //                donationRequest.Cvv
        //            );
        //            return Ok("Donation processed successfully.");
        //        }
        //        catch (Exception ex)
        //        {
        //            return BadRequest($"Error: {ex.Message}");
        //        }
        //    }
        //}
    }
}
