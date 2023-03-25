using MemberPlatformCore.Models;

namespace MemberPlatformCore.Services
{
    public interface IPriceAgreementService
    {
        Task<PriceAgreement> DeleteAsync(int id);

        Task<List<PriceAgreement>> GetAllAsync();

        Task<PriceAgreement> GetByIdAsync(int id);

        Task<PriceAgreement> PostAsync(PriceAgreement priceAgreement);

        Task<PriceAgreement> UpdateAsync(int id, PriceAgreement priceAgreement);
    }
}
