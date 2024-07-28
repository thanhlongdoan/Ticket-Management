using Moq;
using TicketManagement.API.Repositories.Interfaces;

namespace TicketManagement.API.Test.Mocks
{
    public class MockIUnitOfWork
    {
        public static Mock<IUnitOfWork> GetMock()
        {
            var mock = new Mock<IUnitOfWork>();
            Mock<ITicketRepository> mockITicketRepository = MockITicketRepository.GetMock();
            mock.Setup(u => u.TicketRepository).Returns(() => mockITicketRepository.Object);
            return mock;
        }
    }
}
