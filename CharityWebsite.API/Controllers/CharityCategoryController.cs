using CharityWebsite.Core.Data;
using CharityWebsite.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityWebsite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharityCategoryController : ControllerBase
    {
        private readonly ICharityCategoryService _service;

        public CharityCategoryController(ICharityCategoryService service)
        {
            _service = service;
        }

        [HttpGet("GetAllCharityCategories")]
        public ActionResult<List<Charitycategory>> GetAllCharityCategories() => _service.GetAllCharityCategories();

        [HttpGet("GetCharityCategoryById/{id}")]
        public ActionResult<Charitycategory> GetCharityCategoryById(int id) => _service.GetCharityCategoryById(id);

        [HttpPost("CreateCharityCategory")]
        public IActionResult CreateCharityCategory([FromBody] Charitycategory charityCategory)
        {
            _service.CreateCharityCategory(charityCategory);
            return Ok();
        }

        [HttpPut("UpdateCharityCategory")]
        public IActionResult UpdateCharityCategory([FromBody] Charitycategory charityCategory)
        {
            _service.UpdateCharityCategory(charityCategory);
            return Ok();
        }

        [HttpDelete("DeleteCharityCategory/{id}")]
        public IActionResult DeleteCharityCategory(int id)
        {
            _service.DeleteCharityCategory(id);
            return Ok();
        }

        [HttpGet("GetAllCharityCategoriesWithCharities")]
        public ActionResult<List<CharityCategoryWithCharities>> GetAllCharityCategoriesWithCharities()
        {
            var result = _service.GetAllCharityCategoriesWithCharities();
            return Ok(result);
        }

        //the new 
        [HttpGet("GetCategoriesAndPaidCharities")]
        public ActionResult<List<CharityCategoryWithPaidCharities>> GetCategoriesAndPaidCharities()
        {
            var result = _service.GetCategoriesAndPaidCharities();
            return Ok(result);
        }


    }
}
