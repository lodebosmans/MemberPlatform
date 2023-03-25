using MemberPlatformCore.Models;

namespace MemberPlatformCore.Services
{
    public interface ITicketItemService
    {
        Task<TicketItem> DeleteAsync(int id);

        Task<List<TicketItem>> GetAllAsync();

        Task<TicketItem> GetByIdAsync(int id);

        Task<TicketItem> PostAsync(TicketItem ticketItem);

        Task<TicketItem> UpdateAsync(int id, TicketItem ticketItem);
    }
}
