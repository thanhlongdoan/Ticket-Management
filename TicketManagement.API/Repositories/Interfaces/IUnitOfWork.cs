namespace TicketManagement.API.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        ITicketRepository TicketRepository { get; }

        Task SaveChangesAsync();

        void Dispose();
    }
}
