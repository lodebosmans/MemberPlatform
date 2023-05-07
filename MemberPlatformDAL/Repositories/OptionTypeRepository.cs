using MemberPlatformDAL.Data;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;
using Microsoft.EntityFrameworkCore;

namespace MemberPlatformDAL.Repositories
{
    public class OptionTypeRepository : GenericRepository<OptionTypeEntity>, IOptionTypeRepository
    {
        private DataContext _context;

        public OptionTypeRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<OptionTypeEntity> GetOptionTypeAsync(string optionTypeName)
        {
            OptionTypeEntity optionType = await _context.OptionTypes.SingleOrDefaultAsync(o => o.Name == optionTypeName);
            if (optionType == null)
            {
                throw new ApplicationException("Option for " + optionTypeName + " not found.");
            }
            return optionType;
        }

    }
}
