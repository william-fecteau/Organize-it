using System;
using System.Threading.Tasks;
using mchacks2022.Data;
using mchacks2022.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace mchacks2022.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {

        private readonly AppDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWebHostEnvironment _env;

        public TestController(AppDbContext dbContext, UserManager<IdentityUser> userManager, IWebHostEnvironment env)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _env = env;
        }

        [HttpGet]
        [Route("seed")]
        public async Task<IActionResult> SeedDb()
        {
            if (_env.IsProduction()) return NotFound();

            var gamer = new IdentityUser()
            {
                Email = "gamer@gmail.com",
                UserName = "gamer"
            };
            var result = await _userManager.CreateAsync(gamer, "1234");
            var user = await _userManager.FindByNameAsync("gamer");


            return Ok("Database seeded");
        }

        [HttpGet]
        [Authorize]
        [Route("authTest")]
        public IActionResult AuthTest()
        {
            var username = User.GetLoggedInUserName();
            return Ok($"Hi {username}!");
        }
    }
}
