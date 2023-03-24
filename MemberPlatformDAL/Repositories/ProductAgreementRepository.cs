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
    public class ProductAgreementRepository : GenericRepository<ProductAgreementEntity>, IProductAgreementRepository
    {
        private DataContext _context;

        public ProductAgreementRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public bool ProductAgreementExists(int id)
        {
            return _context.ProductAgreements.Any(e => e.Id == id);
        }

    }
}
