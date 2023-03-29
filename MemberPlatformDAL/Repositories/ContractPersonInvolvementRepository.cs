using MemberPlatformDAL.Data;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public class ContractPersonInvolvementRepository : GenericRepository<ContractPersonInvolvementEntity>, IContractPersonInvolvementRepository
    {
        private DataContext _context;

        public ContractPersonInvolvementRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
