using System;
using System.Threading.Tasks;
using mchacks2022.Data;
using mchacks2022.Entities;
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
            var gamer = new IdentityUser()
            {
                Email = "gamer@gmail.com",
                UserName = "gamer"
            };
            _userManager.CreateAsync(gamer, "1234").GetAwaiter().GetResult();
            var user = _userManager.FindByNameAsync("gamer").GetAwaiter().GetResult();


            // Semesters
            var h2022 = new Semester()
            {
                Id = "H2022",
                NbWeeks = 15,
                EasternStartDate = DateTime.Now,
                FkUserId = user.Id
            };
            _dbContext.Semesters.Add(h2022);

            var a2022 = new Semester()
            {
                Id = "A2022",
                NbWeeks = 15,
                EasternStartDate = DateTime.Now.AddDays(16*7),
                FkUserId = user.Id
            };
            _dbContext.Semesters.Add(a2022);

            // Classes
            var mat1919 = new Class()
            {
                Id = "MAT-1919",
                Name = "Computer science math",
                FkUserId = user.Id
            };
            _dbContext.Classes.Add(mat1919);

            var mat1900 = new Class()
            {
                Id = "MAT-1900",
                Name = "Engineer math",
                FkUserId = user.Id
            };
            _dbContext.Classes.Add(mat1900);

            // Semester classes
            var semesterMat1919 = new SemesterClass()
            {
                FkSemesterId = h2022.Id,
                FkClassId = mat1919.Id,
                TeacherEmail = "pierre.laroche@gmail.com",
                TeacherName = "Pierre Laroche",
                FkUserId = user.Id
            };
            _dbContext.SemesterClass.Add(semesterMat1919);

            var semesterMat1900 = new SemesterClass()
            {
                FkSemesterId = h2022.Id,
                FkClassId = mat1900.Id,
                TeacherEmail = "caillou.ledur@gmail.com",
                TeacherName = "Caillou Ledur",
                FkUserId = user.Id
            };
            _dbContext.SemesterClass.Add(semesterMat1900);

            // Schedules
            var mat1919Friday = new SemesterClassSchedule()
            {
                Id = Guid.NewGuid(),
                FkSemesterId = h2022.Id,
                FkClassId = mat1919.Id,
                ClassType = ClassType.Online,
                DayOfWeek = DayOfWeek.Friday,
                DurationHours = TimeSpan.FromHours(2),
            };
            _dbContext.SemesterClassSchedule.Add(mat1919Friday);

            var mat1919Wednesday = new SemesterClassSchedule()
            {
                Id = Guid.NewGuid(),
                FkSemesterId = h2022.Id,
                FkClassId = mat1919.Id,
                ClassType = ClassType.InClass,
                DayOfWeek = DayOfWeek.Wednesday,
                DurationHours = TimeSpan.FromHours(3),
            };
            _dbContext.SemesterClassSchedule.Add(mat1919Wednesday);

            var mat1900Monday = new SemesterClassSchedule()
            {
                Id = Guid.NewGuid(),
                FkSemesterId = h2022.Id,
                FkClassId = mat1900.Id,
                ClassType = ClassType.Comodal,
                DayOfWeek = DayOfWeek.Monday,
                DurationHours = TimeSpan.FromHours(1),
            };
            _dbContext.SemesterClassSchedule.Add(mat1900Monday);


            var mat1900Thursday = new SemesterClassSchedule()
            {
                Id = Guid.NewGuid(),
                FkSemesterId = h2022.Id,
                FkClassId = mat1900.Id,
                ClassType = ClassType.Comodal,
                DayOfWeek = DayOfWeek.Thursday,
                DurationHours = TimeSpan.FromHours(4),
            };
            _dbContext.SemesterClassSchedule.Add(mat1900Thursday);

            // TODO: Those datasets are not seeded yet
            // Exam

            // Deadlines

            await _dbContext.SaveChangesAsync();

            return Ok(user);
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
