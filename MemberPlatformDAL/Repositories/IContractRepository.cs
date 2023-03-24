using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public interface IContractRepository : IGenericRepository<ContractEntity>
    {
        bool ContractExists(int id);
    }
}
