using MemberPlatformDAL.Data;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public class SalesItemRepository : GenericRepository<SalesItemEntity>, ISalesItemRepository
    {
        private DataContext _context;

        public SalesItemRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public bool SalesItemExists(int id)
        {
            return _context.SalesItems.Any(e => e.Id == id);
        }
    }
}
