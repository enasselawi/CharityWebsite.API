using CharityWebsite.Core.Data;
using CharityWebsite.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityWebsite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            this.testimonialService = testimonialService;
        }

        [HttpGet("GetAllTestimonials")]
        public ActionResult<List<Testimonial>> GetAllTestimonials()
        {
            return Ok(testimonialService.GetAllTestimonials());
        }

        [HttpGet("GetTestimonialById/{id}")]
        public ActionResult<Testimonial> GetTestimonialById(int id)
        {
            var testimonial = testimonialService.GetTestimonialById(id);
            if (testimonial == null)
            {
                return NotFound();
            }
            return Ok(testimonial);
        }

        [HttpPost("CreateTestimonial")]
        public ActionResult CreateTestimonial([FromBody] Testimonial testimonial)
        {
            testimonialService.CreateTestimonial(testimonial);
            return CreatedAtAction(nameof(GetTestimonialById), new { id = testimonial.Testimonalid }, testimonial);
        }

        [HttpPut("UpdateTestimonial/{id}")]
        public IActionResult UpdateTestimonial(int id, [FromBody] Testimonial testimonial)
        {
            if (id != testimonial.Testimonalid)
            {
                return BadRequest("ID mismatch");
            }

            testimonialService.UpdateTestimonial(testimonial);
            return NoContent();
        }

        [HttpDelete("DeleteTestimonial/{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            testimonialService.DeleteTestimonial(id);
            return NoContent();
        }
    }
}
