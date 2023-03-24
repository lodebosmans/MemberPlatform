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
    public class ContractRepository : GenericRepository<ContractEntity>, IContractRepository
    {
        private DataContext _context;

        public ContractRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        public bool ContractExists(int id)
        {
            return _context.Contracts.Any(a => a.Id == id);
        }
    }
}
