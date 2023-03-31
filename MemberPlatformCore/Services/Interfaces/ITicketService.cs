using MemberPlatformCore.Models;

namespace MemberPlatformCore.Services
{
    public interface ITicketService
    {
        Task<Ticket> DeleteAsync(int id);

        Task<List<Ticket>> GetAllAsync();

        Task<Ticket> GetByIdAsync(int id);

        Task<Ticket> PostAsync(Ticket ticket);

        Task<Ticket> UpdateAsync(int id, Ticket ticket);
    }
}
