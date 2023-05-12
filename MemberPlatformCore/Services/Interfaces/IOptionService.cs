using MemberPlatformCore.Models;

namespace MemberPlatformCore.Services
{
    public interface IOptionService
    {
        Task<Option> GetByIdAsync(int id);

        Task<List<Option>> GetAllAsync();

        Task<Option> DeleteAsync(int id);

        Task<Option> UpdateAsync(int id, Option option);

        Task<Option> PostAsync(Option option);
        Task<List<Option>> GetAllByTypeAsync(string type);
    }
}
