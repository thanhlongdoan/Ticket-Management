namespace TicketManagement.API.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        public string IssueType { get; set; } = string.Empty;

        public string Summary { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Attachment { get; set; } = string.Empty;

        public string Assignee { get; set; } = string.Empty;

        public DateTime? PlannedStart { get; set; }

        public DateTime? DueDate { get; set; }

        public double? OriginalEstimate { get; set; }

        public double? RemainingEstimate { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}
