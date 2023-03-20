using MemberPlatformCore.Models;

namespace MemberPlatformCore.Services
{
    public interface IOptionService
    {
        Task<Option> GetByIdAsync(int id);

        Task<List<Option>> GetAllAsync();
    }
}
