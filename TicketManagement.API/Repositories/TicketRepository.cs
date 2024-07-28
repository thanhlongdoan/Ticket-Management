using Microsoft.EntityFrameworkCore;
using TicketManagement.API.Data;
using TicketManagement.API.Models;
using TicketManagement.API.Repositories.Interfaces;

namespace TicketManagement.API.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        protected DataContext _context;
        protected DbSet<Ticket> dbSet;

        public TicketRepository(DataContext dataContext)
        {
            _context = dataContext;
            dbSet = _context.Set<Ticket>();
        }

        public async Task<List<Ticket>> GetAllAsync()
        {
            return await _context.Ticket.ToListAsync();
        }

        public async Task<Ticket> GetByIdAsync(int id)
        {
            return await _context.Ticket.FindAsync(id);
        }

        public Ticket CreateAsync(Ticket artist)
        {
            _context.Ticket.Add(artist);
            return artist;
        }

        public Ticket UpdateAsync(Ticket artist)
        {
            _context.Ticket.Update(artist);
            return artist;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var artist = await GetByIdAsync(id);
            _context.Ticket.Remove(artist);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
