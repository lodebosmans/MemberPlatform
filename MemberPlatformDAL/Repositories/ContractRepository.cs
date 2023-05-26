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

        public async Task<bool> AdminRightsExists(int personId)
        {
            return await _context.Contracts
                 .Include(c => c.ContractPersonInvolvements)
                 .ThenInclude(cpi => cpi.Role)
                 .AnyAsync(c => c.ContractPersonInvolvements.Any(cpi => cpi.PersonId == personId) && c.ContractPersonInvolvements.Any(r => r.Role.Name == "Admin" && r.Role.OptionType.Name == "PlatformRole" && c.ContractDate.Year == DateTime.Now.Year));
        }

        public async Task<List<ContractEntity>> GetAllWithPropsAsync()
        {
            return await _context.Contracts
                 .Include(c => c.ContractPersonInvolvements)
                 .ThenInclude(p => p.Person)
                 .Include(pa => pa.ProductAgreements)
                 .ThenInclude(pr => pr.ProductDefinition)
                 .Include(pa => pa.PriceAgreements)
                 .ThenInclude(o => o.PriceAgreementStatus)
                 .Where(c => c.ContractPersonInvolvements.Any(cpi => cpi.ContractId == c.Id)
                   && c.PriceAgreements.Any(pa => pa.ContractId == c.Id) && c.ProductAgreements.Any(pr =>pr.ProductDefinition.Id == pr.ProductDefinitionId))
                 .ToListAsync();
        }


    }
}
