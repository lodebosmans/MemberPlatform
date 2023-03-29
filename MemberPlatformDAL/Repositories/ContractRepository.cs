using MemberPlatformDAL.Data;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public class ContractRepository : GenericRepository<ContractEntity>, IContractRepository
    {
        private DataContext _context;

        public ContractRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
