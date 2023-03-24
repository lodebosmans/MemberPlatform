using MemberPlatformDAL.Data;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;
using Microsoft.EntityFrameworkCore;

namespace MemberPlatformDAL.Repositories
{
    public class AddressRepository : GenericRepository<AddressEntity>, IAddressRepository
    {
        private DataContext _context;

        public AddressRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public bool AddressExists(int id)
        {
            return _context.Addresses.Any(a => a.Id == id);
        }

        public async Task<List<AddressEntity>> GetAllAsync()
        {
            return await _context.Addresses
                .Include(a => a.AddressType)
                 .ToListAsync();
        }
        public async Task<AddressEntity> UpdateAsync(AddressEntity entity)
        {
            _context.Addresses.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(AddressEntity entity)
        {
            _context.Addresses.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<AddressEntity> AddAsync(AddressEntity entity)
        {
            await _context.Addresses.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
