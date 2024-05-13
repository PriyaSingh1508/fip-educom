using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using Edu.Shared.Models;
using Edu.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Azure.Storage.Blobs.Specialized;
using System.Text.Json;
using Edu.Shared.Interfaces.IServices;

namespace Edu.Services.Service
{
    public class BlobService:IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }
        public async Task<string> Upload(TutorialCategoryDTO tutorialCategoryDTO)
        {
            try
            {
                var container = _blobServiceClient.GetBlobContainerClient("cdn");
                var blobClient = container.GetAppendBlobClient("tutorial/category/category1.json");
                var jsonBytes = JsonSerializer.SerializeToUtf8Bytes(tutorialCategoryDTO);
                using var stream = new MemoryStream(jsonBytes);


                // Create or retrieve the append blob
                if (!await blobClient.ExistsAsync())
                {
                    await blobClient.CreateAsync();
                }

                // Append data to the blob
               var a= await blobClient.AppendBlockAsync(stream);
                return "Data Appended to Blob Successfully.";
            }
            catch (Exception ex)
            {
                return $"Error updating data: {ex.Message}";
            }



        }

    }
}
