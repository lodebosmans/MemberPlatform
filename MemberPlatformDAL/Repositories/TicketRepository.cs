using MemberPlatformDAL.Data;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public class TicketRepository : GenericRepository<TicketEntity>, ITicketRepository
    {
        private DataContext _context;

        public TicketRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
