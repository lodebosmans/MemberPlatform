using MemberPlatformCore.Models;

namespace MemberPlatformCore.Services
{
    public interface IProductAgreementService
    {
        Task<ProductAgreement> DeleteAsync(int id);
        Task<List<ProductAgreement>> GetAllAsync();
        Task<ProductAgreement> GetByIdAsync(int id);
        Task<ProductAgreement> PostAsync(ProductAgreement productAgreement);
        Task<ProductAgreement> UpdateAsync(int id, ProductAgreement productAgreement);
    }
}