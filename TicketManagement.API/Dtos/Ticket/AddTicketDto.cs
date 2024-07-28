using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TicketManagement.API.Dtos.Ticket
{
    public class AddTicketDto
    {
        [Required(ErrorMessage = "The Issue type field is required.")]
        [DefaultValue("Bug")]
        public string IssueType { get; set; }

        [Required(ErrorMessage = "The Summary field is required.")]
        public string Summary { get; set; }

        public string Description { get; set; }

        public IFormFile Attachment { get; set; }

        public string Assignee { get; set; }

        [DataType(DataType.Date)]
        public DateTime? PlannedStart { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }

        [DefaultValue(0)]
        public double? OriginalEstimate { get; set; }

        [DefaultValue(0)]
        public double? RemainingEstimate { get; set; }

        [DefaultValue("Open")]
        public string Status { get; set; }
    }
}
