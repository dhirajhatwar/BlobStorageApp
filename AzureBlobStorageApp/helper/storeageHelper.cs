using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;

namespace AzureBlobStorageApp.helper
{
 public   class storeageHelper
    {
        private readonly BlobServiceClient blobServiceClient;

        public storeageHelper(string storageConnectionString)
        {
            this.blobServiceClient = new BlobServiceClient(storageConnectionString);
            
        }

        public async Task<bool> CreateBlobContainer(string containerName)
        {
            try
            {
                var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
                await containerClient.CreateIfNotExistsAsync(Azure.Storage.Blobs.Models.PublicAccessType.Blob);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;

            }
        }

        public async Task<string> UploadBlob(string filePath, string containerName) {

            var blobName = Path.GetFileName(filePath);
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(blobName);
          var response = await   blobClient.UploadAsync(filePath, true);
            return blobClient.Uri.AbsoluteUri;

        }
    }
}
