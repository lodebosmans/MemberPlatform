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
    public class ContractPersonInvolvementRepository : GenericRepository<ContractPersonInvolvementEntity>, IContractPersonInvolvementRepository
    {
        private DataContext _context;

        public ContractPersonInvolvementRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        public bool ContractPersonInvolvementExists(int id)
        {
            return _context.ContractPersonInvolvements.Any(a => a.Id == id);
        }
    }
}
