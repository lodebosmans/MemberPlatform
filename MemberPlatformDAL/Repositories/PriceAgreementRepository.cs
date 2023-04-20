using MemberPlatformDAL.Data;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

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
    }
}
