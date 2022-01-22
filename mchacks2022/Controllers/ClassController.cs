using System.Linq;
using System.Threading.Tasks;
using mchacks2022.Data;
using mchacks2022.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mchacks2022.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClassController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.Classes.ToListAsync();

            return Ok(result);
        }

        [HttpGet]
        [Route("semesterClass")]
        public async Task<IActionResult> GetSemesterClass()
        {
            var result = await _context.SemesterClass.ToListAsync();

            return Ok(result);
        }

        [HttpGet]
        [Route("semesterClassSchedule")]
        public async Task<IActionResult> GetSemesterClassSchedule()
        {
            var result = await _context.SemesterClassSchedule.ToListAsync();

            return Ok(result);
        }
    }
}
