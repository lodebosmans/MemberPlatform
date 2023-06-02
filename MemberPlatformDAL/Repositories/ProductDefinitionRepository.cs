using MemberPlatformDAL.Data;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;
using Microsoft.EntityFrameworkCore;

namespace MemberPlatformDAL.Repositories
{
    public class ProductDefinitionRepository : GenericRepository<ProductDefinitionEntity>, IProductDefinitionRepository
    {
        private DataContext _context;

        public ProductDefinitionRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        //public async Task<List<ProductDefinitionEntity>> GetAllByIdAsync(int id)
        //{
        //    return await _context.ProductDefinitions
        //        .Include(p => p.ProductAgreements)
        //        .ThenInclude(c => c.Contract)
        //        .ThenInclude(c => c.ContractPersonInvolvements)
        //        .Where(pa => pa.ProductAgreements.Any(c => c.Contract.ContractPersonInvolvements.Any(cpi => cpi.PersonId == id)))
        //        .ToListAsync();
        //}

        public async Task<List<ProductDefinitionEntity>> GetAllByIdAsync(int personId, int year)
        {
            var contracts = await _context.Contracts
                .Include(c => c.ProductAgreements)
                .ThenInclude(pa => pa.ProductDefinition)
                .Include(c => c.ContractPersonInvolvements)
                .ThenInclude(cpi => cpi.Person)
                .Where(c => c.ContractPersonInvolvements.Any(cpi => cpi.PersonId == personId) && c.ContractDate.Year == year)
                .ToListAsync();

            var productAgreements = contracts.SelectMany(c => c.ProductAgreements).ToList();

            var productDefinitions = productAgreements.Select(pa => pa.ProductDefinition).ToList();

            return productDefinitions;
        }
    }
}
