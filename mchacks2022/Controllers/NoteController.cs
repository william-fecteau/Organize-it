using System;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using mchacks2022.Data;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        [Route("upload")]
        public async Task<IActionResult> UploadNote()
        {
            var testId = Guid.NewGuid();

            var serviceClient = new BlobServiceClient(_blobsConfig.BlobsCnstr);
            var containerClient = serviceClient.GetBlobContainerClient(testId.ToString());

            await containerClient.CreateIfNotExistsAsync();



            return Ok();
        }
    }
}
