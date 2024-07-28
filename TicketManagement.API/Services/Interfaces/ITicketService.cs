using TicketManagement.API.Dtos;
using TicketManagement.API.Dtos.Ticket;
using TicketManagement.API.Models;

namespace TicketManagement.API.Services.Interfaces
{
    public interface ITicketService
    {
        Task<Response<List<Ticket>>> GetAllAsync();
        Task<Response<Ticket>> GetByIdAsync(int id);
        Task<Response<Ticket>> CreateAsync(AddTicketDto dto);
        Task<Response<Ticket>> UpdateAsync(int id, AddTicketDto dto);
        Task<Response<bool>> DeleteAsync(int id);
    }
}
