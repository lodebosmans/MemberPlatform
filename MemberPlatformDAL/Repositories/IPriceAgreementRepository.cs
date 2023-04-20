using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public interface IPriceAgreementRepository : IGenericRepository<PriceAgreementEntity>
    {
        Task<PriceAgreementEntity> SaveAsync(PriceAgreementEntity priceAgreementEntity, int contractId);
    }
}
