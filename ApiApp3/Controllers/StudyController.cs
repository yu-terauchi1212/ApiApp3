using ApiApp3.Data;
using ApiApp3.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiApp3.Controllers
{

    [Route("ApiApp3 / [controller]")]
    [ApiController]
    public class StudyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudyController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Study.ToList());
        }

        [HttpPost]
        public async Task <IActionResult> Create(Study study)
        {
            _context.Study.Add(study);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = study.Id} , study);
        }
    }
}
