using MemberPlatformCore.Models;
using MemberPlatformCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace MemberPlatformApi.Controllers
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
        public async Task<List<Ticket>> GetAllAsync()
        {
            return await _ticketService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Ticket> GetByIdAsync(int id)
        {
            return await _ticketService.GetByIdAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<Ticket> UpdateAsync(int id, Ticket ticket)
        {
            return await _ticketService.UpdateAsync(id, ticket);
        }

        [HttpPost]
        public async Task<Ticket> PostAsync(Ticket ticket)
        {
            return await _ticketService.PostAsync(ticket);
        }

        [HttpDelete("{id}")]
        public async Task<Ticket> DeleteAsync(int id)
        {
            return await _ticketService.DeleteAsync(id);
        }
    }
}
