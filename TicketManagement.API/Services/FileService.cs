using Azure.Storage.Blobs;
using TicketManagement.API.Services.Interfaces;

namespace TicketManagement.API.Services
{
    public class FileService : IFileService
    {
        private BlobServiceClient _blobServiceClient;
        public FileService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        /// <summary>
        /// Upload file to azure storage
        /// </summary>
        /// <param name="fileModel"></param>
        /// <returns></returns>
        public async Task Upload(IFormFile fileModel)
        {
            BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient("ticketmanagmentfilecontainer");
            BlobClient blobClient = blobContainerClient.GetBlobClient(fileModel.FileName);
            await blobClient.UploadAsync(fileModel.OpenReadStream());
        }
    }
}
