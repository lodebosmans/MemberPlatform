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

        public bool OptionTypeExists(int id)
        {
            return _context.OptionTypes.Any(e => e.Id == id);
        }

        public async Task<List<OptionTypeEntity>> GetAllAsync()
        {
            return await _context.OptionTypes
                .ToListAsync();
        }

        public async Task<OptionTypeEntity> UpdateAsync(OptionTypeEntity entity)
        {
            _context.OptionTypes.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
