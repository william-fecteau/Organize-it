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
using Microsoft.EntityFrameworkCore;

namespace mchacks2022.Controllers
{
    [ApiController]
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

        [HttpPost]
        [Route("{semesterName}/{className}/{classNo:int}")]
        public async Task<IActionResult> UploadNote([FromBody]UploadNoteRequest request, [FromRoute] string semesterName, [FromRoute] string className, [FromRoute] int classNo)
        {
            var userId = User.GetLoggedInUserId();

            var semester = await _dbContext.Semesters.FirstOrDefaultAsync(x => x.SemesterName == semesterName);
            var classs = await _dbContext.Classes.FirstOrDefaultAsync(x => x.FkUserId == userId && x.ClassNum == className);
            if (semester == null || classs == null) return BadRequest("Invalid semester or class");

            var semesterClassNotes = await _dbContext.SemesterClassNotes.FirstOrDefaultAsync(x => x.FkClassId == classs.Id && x.FkSemesterId == semester.Id && x.ClassNo == classNo);
            
            // If semesterClassNotes is not already there, create it
            if (semesterClassNotes == null)
            {
                semesterClassNotes = new SemesterClassNotes()
                {
                    Id = Guid.NewGuid(),
                    FkClassId = classs.Id,
                    FkSemesterId = semester.Id,
                    ClassNo = classNo,
                };
                _dbContext.SemesterClassNotes.Add(semesterClassNotes);
            }

            var serviceClient = new BlobServiceClient(_blobsConfig.BlobsCnstr);
            var containerClient = serviceClient.GetBlobContainerClient(userId);

            await containerClient.CreateIfNotExistsAsync();

            var noteId = Guid.NewGuid();
            var note = new Note()
            {
                Id = noteId,
                Filename = request.Filename,
                Extension = request.Extension,
                FkSemesterClassNoteId = semesterClassNotes.Id
            };

            BlobsHelper.UploadBlob($"{noteId}", request.FileContent, containerClient, true);

            return Ok(note);
        }
    }
}
