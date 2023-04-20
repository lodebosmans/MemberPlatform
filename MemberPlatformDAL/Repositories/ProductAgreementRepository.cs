using MemberPlatformDAL.Data;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public class ProductAgreementRepository : GenericRepository<ProductAgreementEntity>, IProductAgreementRepository
    {
        private DataContext _context;

        public ProductAgreementRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        public async Task<ProductAgreementEntity> SaveAsync(ProductAgreementEntity productAgreementEntity, int contractId)
        {
            productAgreementEntity.ContractId = contractId;
            _context.ProductAgreements.Add(productAgreementEntity);
           await _context.SaveChangesAsync();
            return productAgreementEntity;
        }
    }
}
