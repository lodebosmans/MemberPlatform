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
                .Include(o => o.OptionType)
                .ToListAsync();
        }

        public async Task<OptionEntity> UpdateAsync(OptionEntity entity)
        {
            _context.Options.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(OptionEntity entity)
        {
            _context.Options.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
