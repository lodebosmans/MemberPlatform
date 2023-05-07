using MemberPlatformCore.Models;

namespace MemberPlatformCore.Services
{
    public interface ISubscriptionService
    {
        //Task SaveDataAsync(Contract contract, ContractPersonInvolvement contractPersonInvolvement, PriceAgreement priceAgreement, ProductAgreement productAgreement);
        Task SaveDataAsync(int productId, int personId);
        Task<List<Subscription>> GetAllById(int personId, int Year);
        Task<List<Subscription>> GetSubscriptionsAsync();
    }
}
