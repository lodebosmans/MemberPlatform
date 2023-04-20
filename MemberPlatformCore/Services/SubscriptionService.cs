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
        private IMapper _mapper;

        public SubscriptionService(
            IContractRepository contractRepository,
            IContractPersonInvolvementRepository contractPersonInvolvementRepository,
            IProductAgreementRepository productAgreementRepository,
            IPriceAgreementRepository priceAgreementRepository,
            IMapper mapper)
        {
            _contractRepository = contractRepository;
            _personInvolvementRepository = contractPersonInvolvementRepository;
            _productAgreementRepository = productAgreementRepository;
            _priceAgreementRepository = priceAgreementRepository;
            _mapper = mapper;
        }
        public async Task SaveDataAsync(
            Contract contract, ContractPersonInvolvement contractPersonInvolvement, PriceAgreement priceAgreement, ProductAgreement productAgreement)
        {
            ContractEntity contractEntity = _mapper.Map<ContractEntity>(contract);
            ContractPersonInvolvementEntity contractPersonInvolvementEntity = _mapper.Map<ContractPersonInvolvementEntity>(contractPersonInvolvement);
            PriceAgreementEntity priceAgreementEntity = _mapper.Map<PriceAgreementEntity>(priceAgreement);
            ProductAgreementEntity productAgreementEntity = _mapper.Map<ProductAgreementEntity>(productAgreement);
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
