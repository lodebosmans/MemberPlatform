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

        public async Task<List<OptionEntity>> GetAllAsync()
        {
            return await _context.Options
                .Include(o => o.OptionType)
                .ToListAsync();
        }

        public async Task<OptionEntity> GetOptionAsync(string optionName, int optionTypeId)
        {
            OptionEntity option = await _context.Options.SingleOrDefaultAsync(o => o.Name == optionName && o.OptionTypeId == optionTypeId);
            if (option == null)
            {
                throw new ApplicationException("Option for " + optionName + " not found.");
            }
            return option;
        }
    }
}
