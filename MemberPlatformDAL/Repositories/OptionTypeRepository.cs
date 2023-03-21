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

        public async Task<OptionTypeEntity> AddAsync(OptionTypeEntity entity)
        {
            await _context.OptionTypes.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(OptionTypeEntity entity)
        {
            _context.OptionTypes.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<OptionTypeEntity> GetByNameAsync(string name)
        {
            return await _context.OptionTypes.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
