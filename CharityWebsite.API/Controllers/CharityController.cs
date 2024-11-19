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


        [HttpGet("GetCharitiesByUserId/{userId}")]
        public List<Charity> GetCharitiesByUserId(int userId) => charityService.GetCharitiesByUserId(userId);


        [HttpGet("GetAboutUsContent")]
        public IActionResult GetAboutUsContent()
        {
            var content = charityService.GetAboutUsContent();
            if (content == null)
            {
                return NotFound("About Us content not found.");
            }
            return Ok(content);
        }

        [HttpGet("GetHomeContent")]
        public IActionResult GetHomeContent()
        {
            var content = charityService.GetHomeContent();
            if (content == null)
            {
                return NotFound("Home content not found.");
            }
            return Ok(content);
        }

        [HttpPut("UpdateAboutUsContent")]
        public IActionResult UpdateAboutUsContent([FromBody] Aboutuscontent content)
        {
            charityService.UpdateAboutUsContent(content);
            return Ok("About Us content updated successfully.");
        }

        [HttpPut("UpdateHomeContent")]
        public IActionResult UpdateHomeContent([FromBody] Homecontent content)
        {
            charityService.UpdateHomeContent(content);
            return Ok("Home content updated successfully.");
        }






    }
}
