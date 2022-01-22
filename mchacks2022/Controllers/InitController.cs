using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mchacks2022.Data;
using mchacks2022.DTOs;
using mchacks2022.Entities;
using mchacks2022.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mchacks2022.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class InitController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public InitController(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Gamer()
        {
            var userId = User.GetLoggedInUserId();
            var user = await _userManager.FindByIdAsync(userId);
            var semesters = await _context.Semesters.Where(x => x.FkUserId == userId).ToListAsync();

            return Ok( new InitResponse() { user = user, semesters = semesters });
        }
    }
}
