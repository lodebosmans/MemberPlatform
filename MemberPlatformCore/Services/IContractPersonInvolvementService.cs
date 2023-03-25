using MemberPlatformCore.Models;

namespace MemberPlatformCore.Services
{
    public interface IContractPersonInvolvementService
    {
        Task<ContractPersonInvolvement> DeleteAsync(int id);

        Task<List<ContractPersonInvolvement>> GetAllAsync();

        Task<ContractPersonInvolvement> GetByIdAsync(int id);

        Task<ContractPersonInvolvement> PostAsync(ContractPersonInvolvement contractPersonInvolvement);

        Task<ContractPersonInvolvement> UpdateAsync(int id, ContractPersonInvolvement contractPersonInvolvement);
    }
}
