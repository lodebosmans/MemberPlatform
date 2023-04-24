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
            int contractTypeId = await _optionRepository.GetContractTypeIdForSubscriptionAsync();
            ProductDefinitionEntity product = await _productDefinitionRepository.GetByIdAsync(productId);
            int statusId = await _optionRepository.GetPriceAgreementStatusIdForSubscriptionAsync();
            int roleId = await _optionRepository.GetRoleIdForSubscription();

            ContractEntity contractEntity = new ContractEntity();
            contractEntity.ContractDate = DateTime.Now;
            contractEntity.ContractTypeId = contractTypeId;
            ProductAgreementEntity productAgreementEntity = new ProductAgreementEntity();
            productAgreementEntity.ProductDefinitionId = productId;
            ContractPersonInvolvementEntity contractPersonInvolvementEntity = new ContractPersonInvolvementEntity();
            contractPersonInvolvementEntity.PersonId = personId;
            contractPersonInvolvementEntity.RoleId = roleId;
            PriceAgreementEntity priceAgreementEntity = new PriceAgreementEntity();
            priceAgreementEntity.PriceAgreementStatusId = statusId;
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
