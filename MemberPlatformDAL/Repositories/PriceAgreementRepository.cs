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

        public bool PriceAgreementExists(int id)
        {
            return _context.PriceAgreements.Any(a => a.Id == id);
        }
    }
}
