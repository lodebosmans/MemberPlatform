using MemberPlatformDAL.Data;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;
using Microsoft.EntityFrameworkCore;

namespace MemberPlatformDAL.Repositories
{
    public class PersonRepository : GenericRepository<PersonEntity>, IPersonRepository
    {
        private DataContext _context;

        public PersonRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public bool PersonExists(int id)
        {
            return _context.Persons.Any(e => e.Id == id);
        }

        public async Task<IEnumerable<PersonEntity>> GetAllWithAddressAsync()
        {
            return await _context.Persons
                .Include(p => p.Address)
                .ThenInclude(a => a.AddressType)
                .ToListAsync();
        }
    }
}