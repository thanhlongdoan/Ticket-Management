using TicketManagement.API.Data;
using TicketManagement.API.Repositories.Interfaces;

namespace TicketManagement.API.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext _context;

        public ITicketRepository TicketRepository { get; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
            TicketRepository = new TicketRepository(context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
