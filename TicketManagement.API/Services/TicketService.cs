using TicketManagement.API.Dtos;
using TicketManagement.API.Dtos.Ticket;
using TicketManagement.API.Models;
using TicketManagement.API.Repositories.Interfaces;
using TicketManagement.API.Services.Interfaces;

namespace TicketManagement.API.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public TicketService(IConfiguration configuration, IUnitOfWork unitOfWork, IFileService fileService)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _fileService = fileService;
            _ticketRepository = _unitOfWork.TicketRepository;
        }

        /// <summary>
        /// Get all tickets
        /// </summary>
        /// <returns></returns>
        public async Task<Response<List<Ticket>>> GetAllAsync()
        {
            var response = new Response<List<Ticket>>();
            var tickets = await _ticketRepository.GetAllAsync();
            response.Data = tickets;
            return response;
        }

        /// <summary>
        /// Get ticket by ticket id
        /// </summary>
        /// <param name="id">ticket id</param>
        /// <returns></returns>
        public async Task<Response<Ticket>> GetByIdAsync(int id)
        {
            var response = new Response<Ticket>();
            var ticket = await _ticketRepository.GetByIdAsync(id);
            if (ticket == null)
            {
                response.Success = false;
                response.Message = "Ticket not found";
                return response;
            }
            response.Data = ticket;
            return response;
        }

        /// <summary>
        /// Create ticket by model
        /// </summary>
        /// <param name="dto">AddTicketDto</param>
        /// <returns></returns>
        public async Task<Response<Ticket>> CreateAsync(AddTicketDto dto)
        {
            var response = new Response<Ticket>();
            var ticket = new Ticket
            {
                IssueType = dto.IssueType,
                Summary = dto.Summary,
                Description = dto.Description,
                Assignee = dto.Assignee,
                PlannedStart = dto.PlannedStart,
                DueDate = dto.DueDate,
                OriginalEstimate = dto.OriginalEstimate,
                RemainingEstimate = dto.RemainingEstimate,
                Status = "Open"
            };

            if (!string.IsNullOrEmpty(dto.Attachment?.FileName))
            {
                string attachmentPath = string.Format("{0}{1}", _configuration["AzureStoragePath"], dto.Attachment?.FileName);
                ticket.Attachment = attachmentPath;
            }

            try
            {
                var createdTicket = _ticketRepository.CreateAsync(ticket);

                if (dto.Attachment != null)
                {
                    await _fileService.Upload(dto.Attachment);
                }

                await _unitOfWork.SaveChangesAsync();
                response.Data = createdTicket;
            }
            catch (Exception e)
            {
                // Rollback transaction if error occurs
                _unitOfWork.Dispose();
                response.Data = null;
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        /// <summary>
        /// Update ticket by id and model
        /// </summary>
        /// <param name="id">Ticket id</param>
        /// <param name="dto">AddTicketDto</param>
        /// <returns></returns>
        public async Task<Response<Ticket>> UpdateAsync(int id, AddTicketDto dto)
        {
            var response = new Response<Ticket>();
            var ticket = await _ticketRepository.GetByIdAsync(id);

            if (ticket == null)
            {
                response.Success = false;
                response.Message = "Ticket not found";
                return response;
            }

            if (!string.IsNullOrEmpty(dto.Attachment?.FileName))
            {
                string attachmentPath = string.Format("{0}{1}", _configuration["AzureStoragePath"], dto.Attachment?.FileName);
                ticket.Attachment = attachmentPath;
            }

            ticket.IssueType = dto.IssueType;
            ticket.Summary = dto.Summary;
            ticket.Description = dto.Description;
            ticket.Assignee = dto.Assignee;
            ticket.PlannedStart = dto.PlannedStart;
            ticket.DueDate = dto.DueDate;
            ticket.OriginalEstimate = dto.OriginalEstimate;
            ticket.RemainingEstimate = dto.RemainingEstimate;
            ticket.Status = dto.Status;

            try
            {
                var createdTicket = _ticketRepository.UpdateAsync(ticket);

                if (dto.Attachment != null)
                {
                    await _fileService.Upload(dto.Attachment);
                }

                await _unitOfWork.SaveChangesAsync();
                response.Data = createdTicket;
            }
            catch (Exception e)
            {
                // Rollback transaction if error occurs
                _unitOfWork.Dispose();
                response.Data = null;
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        /// <summary>
        /// Delete ticket by ticket id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Response<bool>> DeleteAsync(int id)
        {
            var response = new Response<bool>();
            var deleted = await _ticketRepository.DeleteAsync(id);
            response.Data = deleted;
            return response;
        }
    }
}
