using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Edu.Shared.Interfaces.IServices;
using Edu.Shared.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Edu.Services.Service
{
    public class ImageService:IImageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        public ImageService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }
        public async Task<string> Upload(TechImage techImage)
        {
            var container = _blobServiceClient.GetBlobContainerClient("cdn");
            var blobInstance = container.GetBlobClient("images/" + techImage.Name);
            await blobInstance.UploadAsync(techImage.Image.OpenReadStream(),new BlobHttpHeaders { ContentType=techImage.Image.ContentType });
            return blobInstance.Uri.AbsoluteUri.ToString();




        }


    }
}
