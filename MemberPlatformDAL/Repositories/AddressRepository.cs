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

        public async Task<List<AddressEntity>> GetAllWithAddressTypeAsync()
        {
            return await _context.Addresses
                .Include(a => a.AddressType)
                .ToListAsync();
        }

        public async Task<AddressEntity> GetAddressWithAddressType(int id)
        {
            return await _context.Addresses
                .Include(a => a.AddressType)
                .ThenInclude(t => t.OptionType)
                .Where(x => x.Id == id)
                .SingleAsync();
        }
    }
}
