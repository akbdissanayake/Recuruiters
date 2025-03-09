using Microsoft.AspNetCore.Mvc;
using Recruiters.Domain.Entities;
using Recruiters.Domain.Interfaces;

namespace Recruiters.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruitersController : ControllerBase
    {
        private readonly IRecruiterRepository recruiterRepository;

        public RecruitersController(IRecruiterRepository recruiterRepository)
        {
            this.recruiterRepository = recruiterRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recruiter>>> GetRecruiters()
        {
            return Ok(await recruiterRepository.GetAllRecruitersAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recruiter>> GetRecruiter(int id)
        {
            var recruiter = await recruiterRepository.GetRecruiterByIdAsync(id);
            if (recruiter == null)
                return NotFound();
            return Ok(recruiter);
        }

        [HttpPost]
        public async Task<ActionResult<Recruiter>> CreateRecruiter(Recruiter recruiter)
        {
            var createdRecruiter = await recruiterRepository.AddRecruiterAsync(recruiter);
            return CreatedAtAction(nameof(GetRecruiter), new { id = createdRecruiter.Id }, createdRecruiter);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecruiter(int id, Recruiter recruiter)
        {
            if (id != recruiter.Id)
                return BadRequest();

            var updated = await recruiterRepository.UpdateRecruiterAsync(recruiter);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecruiter(int id)
        {
            var deleted = await recruiterRepository.DeleteRecruiterAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
