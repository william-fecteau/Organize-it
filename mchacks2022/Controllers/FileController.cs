using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using mchacks2022.Data;
using mchacks2022.DTOs;
using mchacks2022.Entities;
using mchacks2022.Extensions;
using mchacks2022.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mchacks2022.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly BlobsConfig _blobsConfig;

        public FileController(AppDbContext dbContext, BlobsConfig blobsConfig)
        {
            _dbContext = dbContext;
            _blobsConfig = blobsConfig;
        }

        [HttpGet]
        [Route("{semesterName}/{file}")]
        public async Task<IActionResult> DownloadNote([FromRoute] string semesterName, [FromRoute] string file)
        {
            var userId = User.GetLoggedInUserId();
                
            var semester = await _dbContext.Semesters.FirstOrDefaultAsync(x => x.SemesterName == semesterName);
            if (semester == null) return BadRequest("Invalid semester");

            var splits = file.Split('.');
            if (splits.Length != 2) return BadRequest("Invalid file");

            var filename = splits[0];
            var extension = splits[1];

            var note = await _dbContext.Notes.FirstOrDefaultAsync(x => x.Filename == filename && x.Extension == extension && x.FkUserId == userId);
            if (note == null) return BadRequest("File not found");

            var serviceClient = new BlobServiceClient(_blobsConfig.BlobsCnstr);
            var containerClient = serviceClient.GetBlobContainerClient(userId);

            await containerClient.CreateIfNotExistsAsync();

            var bytes = BlobsHelper.DownloadBlob(note.Id.ToString(), containerClient);

            return Ok(bytes);
        }


        [HttpPost]
        [Route("{semesterName}/{className}/{classNo:int}")]
        public async Task<IActionResult> UploadNote([FromBody] UploadNoteRequest request, [FromRoute] string semesterName, [FromRoute] string className, [FromRoute] int classNo)
        {
            var userId = User.GetLoggedInUserId();

            var semester = await _dbContext.Semesters.FirstOrDefaultAsync(x => x.SemesterName == semesterName);
            var classs = await _dbContext.Classes.FirstOrDefaultAsync(x => x.FkUserId == userId && x.ClassNum == className);
            if (semester == null || classs == null) return BadRequest("Invalid semester or class");

            var semesterClassNotes = await _dbContext.SemesterClassNotes.FirstOrDefaultAsync(x => x.FkClassId == classs.Id && x.FkSemesterId == semester.Id && x.ClassNo == classNo);

            // If semesterClassNotes is not already there
            if (semesterClassNotes == null) return BadRequest("Invalid semester class note #");

            var serviceClient = new BlobServiceClient(_blobsConfig.BlobsCnstr);
            var containerClient = serviceClient.GetBlobContainerClient(userId);

            await containerClient.CreateIfNotExistsAsync();

            var note = await _dbContext.Notes.FirstOrDefaultAsync(x =>
                x.FkUserId == userId && x.Filename == request.Filename && x.Extension == request.Extension);
            if (note == null)
            {
                note = new Note()
                {
                    Id = Guid.NewGuid(),
                    FkUserId = userId,
                    Filename = request.Filename,
                    Extension = request.Extension,
                    FkSemesterClassNoteId = semesterClassNotes.Id
                };
            }

            _dbContext.Notes.Add(note);
            await _dbContext.SaveChangesAsync();

            // If a file with the same name and extension exists, its gonna be overriden
            var bytes = request.FileContent.SelectMany(BitConverter.GetBytes).ToArray();
            BlobsHelper.UploadBlob($"{note.Id}", bytes, containerClient, true);

            return Ok(note);
        }
    }
}
