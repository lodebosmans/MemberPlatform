using MemberPlatformCore.Models;

namespace MemberPlatformCore.Services
{
    public interface IContractService
    {
        Task<List<Contract>> GetAllAsync();
        Task<Contract> GetByIdAsync(int id);
        Task<Contract> UpdateAsync(int id, Contract contract);
        Task<Contract> DeleteAsync(int id);
        Task<Contract> PostAsync(Contract contract);
    }
}
