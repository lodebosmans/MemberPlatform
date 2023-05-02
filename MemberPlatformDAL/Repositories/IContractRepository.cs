using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public interface IContractRepository : IGenericRepository<ContractEntity>
    {
        Task<bool> ContractExists(int productId, int personId);
    }
}
