using MemberPlatformDAL.Data;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public class TicketItemRepository : GenericRepository<TicketItemEntity>, ITicketItemRepository
    {
        private DataContext _context;

        public TicketItemRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
