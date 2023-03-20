using MemberPlatformDAL.Data;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;
using Microsoft.EntityFrameworkCore;

namespace MemberPlatformDAL.Repositories
{
    public class OptionRepository : GenericRepository<OptionEntity>, IOptionRepository
    {
        private DataContext _context;

        public OptionRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public bool OptionExists(int id)
        {
            return _context.Options.Any(e => e.Id == id);
        }

        public async Task<List<OptionEntity>> GetAllAsync()
        {
            return await _context.Options
                .ToListAsync();
        }
    }
}
