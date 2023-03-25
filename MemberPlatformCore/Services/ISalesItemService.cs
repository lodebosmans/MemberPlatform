using MemberPlatformCore.Models;

namespace MemberPlatformCore.Services
{
    public interface ISalesItemService
    {
        Task<SalesItem> DeleteAsync(int id);

        Task<List<SalesItem>> GetAllAsync();

        Task<SalesItem> GetByIdAsync(int id);

        Task<SalesItem> PostAsync(SalesItem salesItem);

        Task<SalesItem> UpdateAsync(int id, SalesItem salesItem);
    }
}
