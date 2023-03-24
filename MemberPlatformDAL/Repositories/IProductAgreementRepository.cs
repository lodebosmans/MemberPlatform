using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public interface IProductAgreementRepository : IGenericRepository<ProductAgreementEntity>
    {
        bool ProductAgreementExists(int id);
    }
}
