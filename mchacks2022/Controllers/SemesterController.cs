using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mchacks2022.Data;
using mchacks2022.DTOs;
using mchacks2022.Entities;
using mchacks2022.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mchacks2022.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class SemesterController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SemesterController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllSemesterOfUser()
        {
            var userId = User.GetLoggedInUserId();
            var result = await _context.Semesters.Where(x => x.FkUserId == userId).ToListAsync();

            return Ok(result);
        }

        [HttpGet]
        [Route("{semesterName}")]
        public async Task<IActionResult> GetAllSemesterClassOfUser([FromRoute] string semesterName)
        {

            var userId = User.GetLoggedInUserId();

            var semester =
                await _context.Semesters.FirstOrDefaultAsync(
                    x => x.FkUserId == userId && x.SemesterName == semesterName);
            if (semester == null) return BadRequest("Invalid semester name");

            var allClasses = await _context.SemesterClass
                .Where(x => x.FkUserId == userId && x.FkSemesterId == semester.Id).ToListAsync();

            return Ok(allClasses);
        }

        [HttpGet]
        [Route("{semesterName}/schedules")]
        public async Task<IActionResult> GetAllSemesterClassSchedulesOfUser([FromRoute] string semesterName)
        {
            var userId = User.GetLoggedInUserId();

            var semester =
                await _context.Semesters.FirstOrDefaultAsync(
                    x => x.FkUserId == userId && x.SemesterName == semesterName);
            if (semester == null) return BadRequest("Invalid semester name");

            var response = new List<CompleteSemesterClass>();

            var allClasses = await _context.SemesterClass
                .Where(x => x.FkUserId == userId && x.FkSemesterId == semester.Id).ToListAsync();
            foreach (var classs in allClasses)
            {
                var schedules = await _context.SemesterClassSchedule
                    .Where(x => x.FkSemesterId == semester.Id && x.FkClassId == classs.FkClassId).ToListAsync();

                var completeSemesterClass = new CompleteSemesterClass()
                {
                    SemesterClass = classs,
                    Schedules = schedules
                };
                response.Add(completeSemesterClass);
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateSemester([FromRoute] CreateSemesterRequest request)
        {
            var userId = User.GetLoggedInUserId();

            var semester = new Semester()
            {
                Id = Guid.NewGuid(),
                FkUserId = userId,
                NbWeeks = request.NbWeeks,
                SemesterName = request.SemesterName,
                EasternStartDate = request.EasternStartDate
            };
            var result = await _context.Semesters.AddAsync(semester);

            return Created("", result.Entity);
        }
    }
}
