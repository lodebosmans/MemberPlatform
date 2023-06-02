using MemberPlatformCore.Models;
using MemberPlatformCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace MemberPlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketItemController : ControllerBase
    {
        private readonly ITicketItemService _ticketItemService;

        public TicketItemController(ITicketItemService ticketItemService)
        {
            _ticketItemService = ticketItemService;
        }

        [HttpGet]
        public async Task<List<TicketItem>> GetAllAsync()
        {
            return await _ticketItemService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<TicketItem> GetByIdAsync(int id)
        {
            return await _ticketItemService.GetByIdAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<TicketItem> UpdateAsync(int id, TicketItem ticketItem)
        {
            return await _ticketItemService.UpdateAsync(id, ticketItem);
        }

        [HttpPost]
        public async Task<TicketItem> PostAsync(TicketItem ticketItem)
        {
            return await _ticketItemService.PostAsync(ticketItem);
        }

        [HttpDelete("{id}")]
        public async Task<TicketItem> DeleteAsync(int id)
        {
            return await _ticketItemService.DeleteAsync(id);
        }
    }
}
