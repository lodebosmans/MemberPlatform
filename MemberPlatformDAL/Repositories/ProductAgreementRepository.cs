using MemberPlatformDAL.Data;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public class ProductAgreementRepository : GenericRepository<ProductAgreementEntity>, IProductAgreementRepository
    {
        private DataContext _context;

        public ProductAgreementRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
