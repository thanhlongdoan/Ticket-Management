using TicketManagement.API.Models;

namespace TicketManagement.API.Repositories.Interfaces
{
    public interface ITicketRepository
    {
        Task<List<Ticket>> GetAllAsync();
        Task<Ticket> GetByIdAsync(int id);
        Ticket CreateAsync(Ticket Ticket);
        Ticket UpdateAsync(Ticket Ticket);
        Task<bool> DeleteAsync(int id);
    }
}
