using MemberPlatformDAL.Data;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;
using Microsoft.EntityFrameworkCore;

namespace MemberPlatformDAL.Repositories
{
    public class PriceAgreementRepository : GenericRepository<PriceAgreementEntity>, IPriceAgreementRepository
    {
        private DataContext _context;

        public PriceAgreementRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        public async Task<PriceAgreementEntity> SaveAsync(PriceAgreementEntity priceAgreementEntity, int contractId)
        {
            priceAgreementEntity.ContractId = contractId;
            _context.PriceAgreements.Add(priceAgreementEntity);
            await _context.SaveChangesAsync();
            return priceAgreementEntity;
        }
        public async Task<List<PriceAgreementEntity>> GetByProductPersonYear(int productId, int personId, int year)
        {
            return await _context.PriceAgreements
                .Include(c => c.Contract)
               .ThenInclude(p => p.ContractPersonInvolvements)
               .Include(c => c.Contract)
               .ThenInclude(pr => pr.ProductAgreements)
              .Where(c => c.Contract.ProductAgreements.Any(cpr => cpr.ProductDefinitionId == productId) && c.Contract.ContractPersonInvolvements.Any(cpi => cpi.PersonId == personId)
              && c.Contract.ContractDate.Year == year)
                .ToListAsync();
        }
    }
}
