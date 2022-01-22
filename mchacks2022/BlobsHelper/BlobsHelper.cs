using System.Collections.Generic;
using Azure.Storage.Blobs;
using System.IO;
using System.Linq;
using Azure.Storage.Blobs.Models;

namespace mchacks2022.BlobsHelper
{
    public static class BlobsHelper
    {
        public static byte[] DownloadBlob(string blobName, BlobContainerClient containerClient)
        {
            if (blobName == null || containerClient == null) return null;

            using var stream = new MemoryStream();
            containerClient.GetBlobClient(blobName).DownloadTo(stream);
            stream.Seek(0, SeekOrigin.Begin);

            return stream.ToArray();
        }

        public static void UploadBlob(string blobName, byte[] blobData, BlobContainerClient containerClient, bool overwrite = false)
        {
            if (blobName == null || blobData == null || containerClient == null) return;

            var blobClient = containerClient.GetBlobClient(blobName);

            using var memStream = new MemoryStream(blobData, false);
            blobClient.Upload(memStream, overwrite);
        }

        public static List<BlobHierarchyItem> GetDirectories(string aPrefix, BlobContainerClient containerClient)
        {
            if (aPrefix == null || containerClient == null) return new List<BlobHierarchyItem>();

            return containerClient.GetBlobsByHierarchy(prefix: aPrefix, delimiter: "/").Where(x => x.IsPrefix).ToList();
        }
    }
}
