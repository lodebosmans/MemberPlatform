using MemberPlatformCore.Models;

namespace MemberPlatformCore.Services
{
    public interface ISubscriptionService
    {
        Task SaveDataAsync(Contract contract, ContractPersonInvolvement contractPersonInvolvement, PriceAgreement priceAgreement, ProductAgreement productAgreement);
    }
}
