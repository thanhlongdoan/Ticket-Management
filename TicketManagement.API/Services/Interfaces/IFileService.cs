namespace TicketManagement.API.Services.Interfaces
{
    public interface IFileService
    {
        Task Upload(IFormFile fileModel);
    }
}
