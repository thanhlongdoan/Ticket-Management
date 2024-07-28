using Microsoft.Extensions.Configuration;
using Moq;
using TicketManagement.API.Dtos.Ticket;
using TicketManagement.API.Repositories.Interfaces;
using TicketManagement.API.Services;
using TicketManagement.API.Services.Interfaces;
using TicketManagement.API.Test.Mocks;

namespace TicketManagement.API.Test.ServicesTest
{
    public class TicketServiceTest
    {
        TicketService ticketService;
        Mock<IFileService> mockFileService;
        Mock<IConfiguration> mockConfiguration;
        Mock<IUnitOfWork> mockIUnitOfWork;

        [SetUp]
        public void SetUp()
        {
            mockFileService = new Mock<IFileService>();
            mockConfiguration = new Mock<IConfiguration>();
            mockIUnitOfWork = MockIUnitOfWork.GetMock();
            ticketService = new TicketService(mockConfiguration.Object, mockIUnitOfWork.Object, mockFileService.Object);
        }

        [Test]
        public async Task GetTickets()
        {
            var result = await ticketService.GetAllAsync();
            Assert.That(3, Is.EqualTo(result?.Data?.Count));
        }

        [Test]
        public async Task GetTicketById()
        {
            var result = await ticketService.GetByIdAsync(1);
            var data = result?.Data;
            Assert.That(1, Is.EqualTo(data?.TicketId));
            Assert.That("IssueType 1", Is.EqualTo(data?.IssueType));
            Assert.That("Summary 1", Is.EqualTo(data?.Summary));
        }


        [Test]
        public async Task CreateTicket()
        {
            AddTicketDto ticket = new AddTicketDto()
            {
                IssueType = "IssueType 4",
                Summary = "Summary 4",
                Status = "InProgress",
            };
            var result = await ticketService.CreateAsync(ticket);
            var data = result?.Data;

            var tickets = await ticketService.GetAllAsync();
            Assert.That(4, Is.EqualTo(tickets?.Data?.Count));
        }

        [Test]
        public async Task DeleteTicketById()
        {
            var result = await ticketService.DeleteAsync(1);
            var tickets = await ticketService.GetAllAsync();
            var data = result?.Data;
            Assert.That(2, Is.EqualTo(tickets?.Data?.Count));
        }
    }
}
