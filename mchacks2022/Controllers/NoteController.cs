using System;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using mchacks2022.Data;
using mchacks2022.DTOs;
using mchacks2022.Entities;
using mchacks2022.Extensions;
using Microsoft.AspNetCore.Mvc;
using mchacks2022.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace mchacks2022.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly BlobsConfig _blobsConfig;
        private readonly AppDbContext _dbContext;

        public NoteController(BlobsConfig blobsConfig, AppDbContext dbContext)
        {
            _blobsConfig = blobsConfig;
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("{semesterName}")]
        public async Task<IActionResult> GetAllNotesFromUser([FromRoute] string semesterName, [FromQuery] string classFilter)
        {
            var userId = User.GetLoggedInUserId();

            var result = _dbContext.SemesterClassNotes.Where(x => x.FkSemester.SemesterName == semesterName && x.FkSemester.FkUserId == userId);
            if (!string.IsNullOrEmpty(classFilter)) result = result.Where(x => x.FkClass.ClassNum == classFilter);

            var response = await result.ToListAsync();

            return Ok(response);
        }

        [HttpPost]
        [Route("{semesterName}/{className}")]
        public async Task<IActionResult> Create([FromBody] CreateSemesterClassNoteRequest request, [FromRoute] string semesterName, [FromRoute] string className)
        {
            var userId = User.GetLoggedInUserId();

            var semester = await _dbContext.Semesters.FirstOrDefaultAsync(x => x.FkUserId == userId && x.SemesterName == semesterName);
            if (semester == null) return BadRequest("Invalid semester name");

            var classs = await _dbContext.Classes.FirstOrDefaultAsync(x => x.ClassNum == className);
            if (classs == null) return BadRequest("Invalid class name");

            var semesterClassNote = new SemesterClassNotes()
            {
                ClassNo = request.ClassNo,
                ClassSubject = request.ClassSubject,
                FkClassId = classs.Id,
                FkSemesterId = semester.Id,
                Id = Guid.NewGuid()
            };
            await _dbContext.SemesterClassNotes.AddAsync(semesterClassNote);
            await _dbContext.SaveChangesAsync();


            return Created("", semesterClassNote);
        }
    }
}
