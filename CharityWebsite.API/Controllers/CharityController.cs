using CharityWebsite.Core.Data;
using CharityWebsite.Core.Service;
using CharityWebsite.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityWebsite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharityController : ControllerBase
    {
        private readonly ICharityService charityService;
        public CharityController(ICharityService charityService)
        {
            this.charityService = charityService;
        }
        [HttpGet("GetAllCharities")]
        public List<Charity> GetAllCharities()
        {
            return charityService.GetAllCharities();
        }

        [HttpGet("GetCharityById/{id}")]
        public Charity GetCharityById(int id)
        {
            return charityService.GetCharityById(id);
        }

        [HttpPost("CreateCharity")]
        public void CreateCharity(Charity charity)
        {
            charityService.CreateCharity(charity);
        }

        [HttpPut("UpdateCharity")]
        public void UpdateCharity(Charity charity)
        {
            charityService.UpdateCharity(charity);
        }

        [HttpDelete("DeleteCharity/{id}")]
        public void DeleteCharity(int id)
        {
            charityService.DeleteCharity(id);
        }















    }
}
