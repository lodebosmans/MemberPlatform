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
    }
}
