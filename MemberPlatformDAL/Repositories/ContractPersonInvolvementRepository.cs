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
        public async Task<ContractPersonInvolvementEntity> SaveAsync(ContractPersonInvolvementEntity contractPersonInvolvementEntity, int contractId)
        {
            contractPersonInvolvementEntity.ContractId = contractId;
            _context.ContractPersonInvolvements.Add(contractPersonInvolvementEntity);
            await _context.SaveChangesAsync();
            return contractPersonInvolvementEntity;
        }
    }
}
