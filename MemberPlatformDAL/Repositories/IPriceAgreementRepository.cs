using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public interface IPriceAgreementRepository : IGenericRepository<PriceAgreementEntity>
    {
        bool PriceAgreementExists(int id);
    }
}
