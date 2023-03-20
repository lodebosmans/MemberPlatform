using MemberPlatformCore.Models;

namespace MemberPlatformCore.Services
{
    public interface IOptionTypeService
    {
        Task<List<OptionType>> GetAllAsync();

        Task<OptionType> GetByIdAsync(int id);

        Task<OptionType> UpdateAsync(int id, OptionType optionType);
    }
}
