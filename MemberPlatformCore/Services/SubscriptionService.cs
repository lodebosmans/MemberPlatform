using MemberPlatformDAL.Repositories;
using MemberPlatformDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using MemberPlatformCore.Models;
using AutoMapper;

namespace MemberPlatformCore.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IContractRepository _contractRepository;
        private readonly IContractPersonInvolvementRepository _personInvolvementRepository;
        private readonly IPriceAgreementRepository _priceAgreementRepository;
        private readonly IProductAgreementRepository _productAgreementRepository;
        private readonly IOptionRepository _optionRepository;
        private readonly IProductDefinitionRepository _productDefinitionRepository;
        private IMapper _mapper;

        public SubscriptionService(
            IContractRepository contractRepository,
            IContractPersonInvolvementRepository contractPersonInvolvementRepository,
            IProductAgreementRepository productAgreementRepository,
            IPriceAgreementRepository priceAgreementRepository,
            IOptionRepository optionRepository,
            IProductDefinitionRepository productDefinitionRepository,
            IMapper mapper)
        {
            _contractRepository = contractRepository;
            _personInvolvementRepository = contractPersonInvolvementRepository;
            _productAgreementRepository = productAgreementRepository;
            _priceAgreementRepository = priceAgreementRepository;
            _optionRepository = optionRepository;
            _productDefinitionRepository = productDefinitionRepository;
            _mapper = mapper;
        }
        public async Task SaveDataAsync(int productId, int personId)
        {
            var exist = await _contractRepository.ContractExists(productId, personId);
            if (exist == false)
            {
                OptionEntity contractType = await _optionRepository.GetOptionAsync("Subscription");
                ProductDefinitionEntity product = await _productDefinitionRepository.GetByIdAsync(productId);
                OptionEntity status = await _optionRepository.GetOptionAsync("Submitted");
                OptionEntity role = await _optionRepository.GetOptionAsync("Member");

                ContractEntity contractEntity = new ContractEntity();
                contractEntity.ContractDate = DateTime.Now;
                contractEntity.ContractTypeId = contractType.Id;
                ProductAgreementEntity productAgreementEntity = new ProductAgreementEntity();
                productAgreementEntity.ProductDefinitionId = productId;
                ContractPersonInvolvementEntity contractPersonInvolvementEntity = new ContractPersonInvolvementEntity();
                contractPersonInvolvementEntity.PersonId = personId;
                contractPersonInvolvementEntity.RoleId = role.Id;
                PriceAgreementEntity priceAgreementEntity = new PriceAgreementEntity();
                priceAgreementEntity.PriceAgreementStatusId = status.Id;
                priceAgreementEntity.PriceBillable = product.Price;
                using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
                try
                {
                    await _contractRepository.Insert(contractEntity);
                    var savedContract = await _contractRepository.GetByIdAsync(contractEntity.Id);
                    await _productAgreementRepository.SaveAsync(productAgreementEntity, savedContract.Id);
                    await _priceAgreementRepository.SaveAsync(priceAgreementEntity, savedContract.Id);
                    await _personInvolvementRepository.SaveAsync(contractPersonInvolvementEntity, savedContract.Id);

                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Failed to save data.", ex);
                }
            }

        }
        public async Task<List<Subscription>> GetAllById(int personId, int year)
        {
            var sub = await _productDefinitionRepository.GetAllByIdAsync(personId, year);
            List<Subscription> subs = new List<Subscription>();
            int id = 0;
            foreach (var subItem in sub)
            {
              
                var x = await _priceAgreementRepository.GetByProductPersonYear(subItem.Id, personId, year);
                var status = await _optionRepository.GetByIdAsync(x[x.Count - 1].PriceAgreementStatusId);
                Subscription subscription = new Subscription
                {
                    Name = subItem.Name,
                    PersonId = personId,
                    PriceAgreementStatusId = x[x.Count - 1].PriceAgreementStatusId,
                    PriceAgreementId = x[x.Count - 1].Id,
                    Status = status.Name,
                    Id = id
                };
                //subscription.Name = subItem.Name;
                //subscription.PersonId = personId;
                //subscription.PriceAgreementStatusId = x[x.Count - 1].PriceAgreementStatusId;
                //subscription.PriceAgreementId = x[x.Count - 1].Id;

                //subscription.Status = status.Name;
                //subscription.Id = id;
                

                subs.Add(subscription);
                id = id + 1;
            }
            return subs;
        }
    }
}


//public async Task SaveDataAsync(
//    Contract contract, ContractPersonInvolvement contractPersonInvolvement, PriceAgreement priceAgreement, ProductAgreement productAgreement)
//{
//    ContractEntity contractEntity = _mapper.Map<ContractEntity>(contract);
//    ContractPersonInvolvementEntity contractPersonInvolvementEntity = _mapper.Map<ContractPersonInvolvementEntity>(contractPersonInvolvement);
//    PriceAgreementEntity priceAgreementEntity = _mapper.Map<PriceAgreementEntity>(priceAgreement);
//    ProductAgreementEntity productAgreementEntity = _mapper.Map<ProductAgreementEntity>(productAgreement);
//    using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
//    try
//    {
//        await _contractRepository.Insert(contractEntity);
//        var savedContract = await _contractRepository.GetByIdAsync(contractEntity.Id);
//        await _productAgreementRepository.SaveAsync(productAgreementEntity, savedContract.Id);
//        await _priceAgreementRepository.SaveAsync(priceAgreementEntity, savedContract.Id);
//        await _personInvolvementRepository.SaveAsync(contractPersonInvolvementEntity, savedContract.Id);

//        transaction.Complete();
//    }
//    catch (Exception ex)
//    {
//        throw new ApplicationException("Failed to save data.", ex);
//    }
//}
