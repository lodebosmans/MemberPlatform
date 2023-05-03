using MemberPlatformDAL.Data;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;
using Microsoft.EntityFrameworkCore;

namespace MemberPlatformDAL.Repositories
{
    public class ContractRepository : GenericRepository<ContractEntity>, IContractRepository
    {
        private DataContext _context;

        public ContractRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ContractExists(int productId, int personId)
        {
            return await _context.Contracts
                 .Include(c => c.ContractPersonInvolvements)
                 .Include(pa => pa.ProductAgreements)
                 .ThenInclude(pr => pr.ProductDefinition)
                 .AnyAsync(c => c.ContractPersonInvolvements.Any(cpi => cpi.PersonId == personId) && c.ProductAgreements.Any(pr => pr.ProductDefinitionId == productId && c.ContractDate.Year == DateTime.Now.Year));
                

        }
    }
}
