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

        public async Task<OptionEntity> GetByNameAsync(string name)
        {
            return await _context.Options.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<int> GetContractTypeIdForSubscriptionAsync()
        {
            OptionEntity option = await _context.Options.SingleOrDefaultAsync(o => o.Name == "Subscription");
            if (option == null)
            {
                throw new ApplicationException("Option for subscription not found.");
            }

            return option.Id;
        }

        public async Task<int> GetPriceAgreementStatusIdForSubscriptionAsync()
        {
            OptionEntity option = await _context.Options.SingleOrDefaultAsync(o => o.Name == "Submitted");
            if (option == null)
            {
                throw new ApplicationException("Option for Submitted not found.");
            }
            return option.Id;
        }

        public async Task<int> GetRoleIdForSubscription()
        {
            OptionEntity option = await _context.Options.SingleOrDefaultAsync(o => o.Name == "Member");
            if (option == null)
            {
                throw new ApplicationException("Option for Member not found.");
            }
            return option.Id;
        }
    }
}
