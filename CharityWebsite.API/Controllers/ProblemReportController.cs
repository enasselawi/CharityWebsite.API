using CharityWebsite.Core.Data;
using CharityWebsite.Core.Service;
using CharityWebsite.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityWebsite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemReportController : ControllerBase
    {
        private readonly IProblemreportService problemreportService;
        public ProblemReportController(IProblemreportService problemreportService)
        {
            this.problemreportService = problemreportService;
        }

        // GET: api/ProblemReport
        [HttpGet]
        [Route("GetAll")]
        [ActionName("GetAllProblemReports")]
        public ActionResult<List<Problemreport>> GetAllProblemReports()
        {
            return Ok(problemreportService.GetAllProblemReports());
        }

        [HttpGet("{id}")]
        [ActionName("GetProblemReportById")]
        public ActionResult<Problemreport> GetProblemReportById(int id)
        {
            var result = problemreportService.GetProblemReportById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST: api/ProblemReport
        [HttpPost]
        [ActionName("CreateProblemReport")]
        public ActionResult CreateProblemReport([FromBody] Problemreport problemReport)
        {
            problemreportService.CreateProblemReport(problemReport);
            return CreatedAtAction(nameof(GetProblemReportById), new { id = problemReport.Problemreportid }, problemReport);
        }

        // PUT: api/ProblemReport/{id}
        [HttpPut("{id}")]
        [ActionName("UpdateProblemReport")]
        public IActionResult UpdateProblemReport(int id, [FromBody] Problemreport problemReport)
        {
            if (id != problemReport.Problemreportid)
            {
                return BadRequest();
            }

            problemreportService.UpdateProblemReport(problemReport);
            return NoContent();
        }

        // DELETE: api/ProblemReport/{id}
        [HttpDelete("{id}")]
        [ActionName("DeleteProblemReport")]
        public IActionResult DeleteProblemReport(int id)
        {
            problemreportService.DeleteProblemReport(id);
            return NoContent();
        }

        // GET: api/ProblemReport/Search?problemType={problemType}
        [HttpGet("Search")]
        [ActionName("SearchProblemReportsByType")]
        public ActionResult<List<Problemreport>> SearchProblemReportsByType([FromQuery] string problemType)
        {
            return Ok(problemreportService.SearchProblemReportsByType(problemType));
        }


    }
}



