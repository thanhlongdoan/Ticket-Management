using TicketManagement.API.Models;

namespace TicketManagement.API.Test.TestData
{
    public static class TestDataHelper
    {
        public static List<Ticket> GetFakeTicketList()
        {
            var tickets = new List<Ticket>()
            {
                new Ticket
                {
                    TicketId = 1,
                    IssueType = "IssueType 1",
                    Summary = "Summary 1",
                    Description = "",
                    Attachment = "",
                    Assignee = "",
                    PlannedStart = null,
                    DueDate = null,
                    OriginalEstimate = 2,
                    RemainingEstimate = 1,
                    Status = "Open"
                },
                new Ticket
                {
                    TicketId = 2,
                    IssueType = "IssueType 2",
                    Summary = "Summary 2",
                    Description = "",
                    Attachment = "",
                    Assignee = "",
                    PlannedStart = null,
                    DueDate = null,
                    OriginalEstimate = 2,
                    RemainingEstimate = 1,
                    Status = "Closed"
                },
                new Ticket
                {
                    TicketId = 3,
                    IssueType = "IssueType 3",
                    Summary = "Summary 3",
                    Description = "",
                    Attachment = "",
                    Assignee = "",
                    PlannedStart = null,
                    DueDate = null,
                    OriginalEstimate = 2,
                    RemainingEstimate = 1,
                    Status = "Resolved"
                }
            };

            return tickets;
        }
    }
}
