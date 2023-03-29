using MemberPlatformDAL.Data;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public class ProductUnitRepository : GenericRepository<ProductUnitEntity>, IProductUnitRepository
    {
        private DataContext _context;

        public ProductUnitRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
