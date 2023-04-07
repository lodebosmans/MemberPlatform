using MemberPlatformDAL.Data;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public class PriceAgreementRepository : GenericRepository<PriceAgreementEntity>, IPriceAgreementRepository
    {
        private DataContext _context;

        public PriceAgreementRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
