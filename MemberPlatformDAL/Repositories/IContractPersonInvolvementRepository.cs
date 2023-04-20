using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public interface IContractPersonInvolvementRepository : IGenericRepository<ContractPersonInvolvementEntity>
    {
        Task<ContractPersonInvolvementEntity> SaveAsync(ContractPersonInvolvementEntity contractPersonInvolvementEntity, int contractId);
    }
}
