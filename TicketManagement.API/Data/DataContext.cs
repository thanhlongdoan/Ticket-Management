using Microsoft.EntityFrameworkCore;
using TicketManagement.API.Models;

namespace TicketManagement.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public virtual DbSet<Ticket> Ticket { get; set; }
    }
}
