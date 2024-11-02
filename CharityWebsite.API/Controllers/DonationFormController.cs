using CharityWebsite.Core.Data;
using CharityWebsite.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityWebsite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationFormController : ControllerBase
    {
        private readonly IDonationFormService _donationFormService;

        public DonationFormController(IDonationFormService donationFormService)
        {
            _donationFormService = donationFormService;
        }

        [HttpGet]
        [Route("GetAllDonationForms")]
        public List<Donationform> GetAllDonationForms()
        {
            return _donationFormService.GetAllDonationForms();
        }

        [HttpGet]
        [Route("GetDonationFormById/{id}")]
        public Donationform GetDonationFormById(int id)
        {
            return _donationFormService.GetDonationFormById(id);
        }

        [HttpPost]
        [Route("CreateDonationForm")]
        public void CreateDonationForm(Donationform donationForm)
        {
            _donationFormService.CreateDonationForm(donationForm);
        }

        [HttpPut]
        [Route("UpdateDonationForm")]
        public void UpdateDonationForm(Donationform donationForm)
        {
            _donationFormService.UpdateDonationForm(donationForm);
        }

        [HttpDelete]
        [Route("DeleteDonationForm/{id}")]
        public void DeleteDonationForm(int id)
        {
            _donationFormService.DeleteDonationFormById(id);
        }
    }
}
