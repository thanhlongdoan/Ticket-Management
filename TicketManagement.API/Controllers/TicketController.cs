using Microsoft.AspNetCore.Mvc;
using TicketManagement.API.Dtos.Ticket;
using TicketManagement.API.Services.Interfaces;

namespace TicketManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTicketsAsync(string sortOrder)
        {
            var data = await _ticketService.GetAllAsync();
            switch (sortOrder)
            {
                case "type_desc":
                    data.Data = data.Data.OrderByDescending(s => s.IssueType).ToList();
                    break;
                case "type":
                    data.Data = data.Data.OrderBy(s => s.IssueType).ToList();
                    break;
                case "assignee_desc":
                    data.Data = data.Data.OrderByDescending(s => s.Assignee).ToList();
                    break;
                case "assignee":
                    data.Data = data.Data.OrderBy(s => s.Assignee).ToList();
                    break;
                case "status_desc":
                    data.Data = data.Data.OrderByDescending(s => s.Status).ToList();
                    break;
                case "status":
                    data.Data = data.Data.OrderBy(s => s.Status).ToList();
                    break;
                default:
                    break;
            }
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketByIdAsync(int id)
        {
            return Ok(await _ticketService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateTicketAsync([FromForm] AddTicketDto dto)
        {
            return Ok(await _ticketService.CreateAsync(dto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicketAsync(int id, [FromForm] AddTicketDto dto)
        {
            return Ok(await _ticketService.UpdateAsync(id, dto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketAsync(int id)
        {
            return Ok(await _ticketService.DeleteAsync(id));
        }
    }
}
