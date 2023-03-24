using MemberPlatformDAL.Data;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
