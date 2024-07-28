using Moq;
using TicketManagement.API.Models;
using TicketManagement.API.Repositories.Interfaces;
using TicketManagement.API.Test.TestData;

namespace TicketManagement.API.Test.Mocks
{
    public class MockITicketRepository
    {
        public static Mock<ITicketRepository> GetMock()
        {
            var mock = new Mock<ITicketRepository>();
            var tickets = TestDataHelper.GetFakeTicketList();
            var item = new Ticket();
            mock.Setup(t => t.GetAllAsync())
                .ReturnsAsync(tickets);
            mock.Setup(t => t.GetByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(tickets.FirstOrDefault(x => x.TicketId.Equals(1))));
            mock.Setup(t => t.DeleteAsync(It.IsAny<int>()))
                .Callback<int>(id => tickets
                .Remove(tickets.FirstOrDefault(x => x.TicketId.Equals(id))));
            mock.Setup(t => t.CreateAsync(It.IsAny<Ticket>()))
                .Callback<Ticket>(data => tickets.Add(data))
                .Returns(item);
            return mock;
        }
    }
}
