using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public interface IProductAgreementRepository : IGenericRepository<ProductAgreementEntity>
    {
        Task<ProductAgreementEntity> SaveAsync(ProductAgreementEntity productAgreementEntity, int contractId);
    }
}
