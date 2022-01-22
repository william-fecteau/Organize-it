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
    public class DeadlineController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DeadlineController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.Deadlines.ToListAsync();

            return Ok(result);
        }
    }
}
