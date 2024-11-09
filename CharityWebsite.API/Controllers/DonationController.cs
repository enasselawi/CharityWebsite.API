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

        [HttpPost("ProcessDonation")]
        public IActionResult ProcessDonation(int userID, int charityID, decimal amount, string cardNumber, DateTime expiryDate, string cvv)
        {
            try
            {
                _donationService.ProcessDonation(userID, charityID, amount, cardNumber, expiryDate, cvv);
                return Ok("Donation processed successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

    }
}
