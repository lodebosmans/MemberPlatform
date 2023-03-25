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

        public bool ProductUnitExists(int id)
        {
            return _context.ProductUnits.Any(e => e.Id == id);
        }
    }
}
