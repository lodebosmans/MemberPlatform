using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public interface ITicketRepository : IGenericRepository<TicketEntity>
    {
        bool OptionExists(int id);
    }
}
