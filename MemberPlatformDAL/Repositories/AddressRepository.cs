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
                   .ToListAsync();
        }
    }
}
