using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public interface IOptionRepository : IGenericRepository<OptionEntity>
    {
        Task<OptionEntity> GetByIdAsync(int id);

        Task<OptionEntity> GetByNameAsync(string addressType);
        Task<int> GetContractTypeIdForSubscriptionAsync();
        Task<int> GetPriceAgreementStatusIdForSubscriptionAsync();
        Task<int> GetRoleIdForSubscription();
    }
}
