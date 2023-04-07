using MemberPlatformDAL.Data;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public class OptionTypeRepository : GenericRepository<OptionTypeEntity>, IOptionTypeRepository
    {
        private DataContext _context;

        public OptionTypeRepository(DataContext context) : base(context)
        {
            _context = context;
        }

    }
}
