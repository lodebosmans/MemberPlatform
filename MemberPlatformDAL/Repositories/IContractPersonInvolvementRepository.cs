using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public interface IContractPersonInvolvementRepository : IGenericRepository<ContractPersonInvolvementEntity>
    {
        bool ContractPersonInvolvementExists(int id);
    }
}
