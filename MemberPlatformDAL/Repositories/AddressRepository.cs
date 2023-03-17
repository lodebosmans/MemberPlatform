using MemberPlatformDAL.Data;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
