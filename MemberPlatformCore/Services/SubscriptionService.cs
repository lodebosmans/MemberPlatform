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
        private readonly IOptionTypeRepository _optionTypeRepository;
        private readonly IProductDefinitionRepository _productDefinitionRepository;
        private readonly IPersonRepository _personRepository;
        private IMapper _mapper;

        public SubscriptionService(
            IContractRepository contractRepository,
            IContractPersonInvolvementRepository contractPersonInvolvementRepository,
            IProductAgreementRepository productAgreementRepository,
            IPriceAgreementRepository priceAgreementRepository,
            IOptionRepository optionRepository,
            IOptionTypeRepository optionTypeRepository,
            IProductDefinitionRepository productDefinitionRepository,
            IPersonRepository personRepository,
            IMapper mapper)
        {
            _contractRepository = contractRepository;
            _personInvolvementRepository = contractPersonInvolvementRepository;
            _productAgreementRepository = productAgreementRepository;
            _priceAgreementRepository = priceAgreementRepository;
            _optionRepository = optionRepository;
            _optionTypeRepository = optionTypeRepository;
            _productDefinitionRepository = productDefinitionRepository;
            _personRepository = personRepository;
            _mapper = mapper;
        }
        public async Task SaveDataAsync(int productId, int personId)
        {
            var exist = await _contractRepository.ContractExists(productId, personId);
            if (exist == false)
            {
                OptionTypeEntity contractOptionTypeEntity = await _optionTypeRepository.GetOptionTypeAsync("ContractType");
                OptionEntity contractType = await _optionRepository.GetOptionAsync("Subscription", contractOptionTypeEntity.Id);

                OptionTypeEntity statusOptionTypeEntity = await _optionTypeRepository.GetOptionTypeAsync("Status");
                OptionEntity status = await _optionRepository.GetOptionAsync("Submitted", statusOptionTypeEntity.Id);

                OptionTypeEntity roleOptionTypeEntity = await _optionTypeRepository.GetOptionTypeAsync("Role");
                OptionEntity role = await _optionRepository.GetOptionAsync("Participant", roleOptionTypeEntity.Id);

                ProductDefinitionEntity product = await _productDefinitionRepository.GetByIdAsync(productId);

                ContractEntity contractEntity = new ContractEntity();
                contractEntity.ContractDate = DateTime.Now;
                contractEntity.ContractTypeId = contractType.Id;
                contractEntity.StartDate = new DateTime(product.StartDate.Year, 1, 1);
                contractEntity.EndDate = new DateTime(product.StartDate.Year, 12, 31);
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
                    var person = await _personRepository.GetByIdAsync(personId);
                Subscription subscription = new Subscription
                {
                    Name = subItem.Name,
                    PersonId = personId,
                    PriceAgreementStatusId = x[x.Count - 1].PriceAgreementStatusId,
                    PriceAgreementId = x[x.Count - 1].Id,
                    Status = status.Name,
                    Id = id,
                    LastName = person.LastName,
                    FirstName = person.FirstName,
                    // PriceAgreements = x

                    };
                List<PriceAgreement> priceAgreements = new List<PriceAgreement>();
                foreach (var agreement in x)
                {
                    var y = await _optionRepository.GetByIdAsync(agreement.PriceAgreementStatusId);
                    PriceAgreement priceAgreement = new PriceAgreement
                    {
                        PriceAgreementStatusId = agreement.PriceAgreementStatusId,
                        Id = agreement.Id,
                        Status = y.Name,
                        Comment = agreement.Comment,
                        DiscountTypeId = agreement.DiscountTypeId,
                        ApproverId = agreement.ApproverId,
                        ContractId = agreement.ContractId,
                        DiscountAmount = agreement.DiscountAmount,
                        PriceBillable = agreement.PriceBillable,
                        StructuredMessage = agreement.StructuredMessage,
                        PaymentDate = agreement.PaymentDate,
                    };

                    priceAgreements.Add(priceAgreement);
                }

                subscription.PriceAgreements = priceAgreements;
                subs.Add(subscription);
                    id ++;
                }

            return subs;
        }
        //public async Task<List<Subscription>> GetSubscriptionsAsync()
        //{
        //    var contracts = await _contractRepository.GetAllWithPropsAsync();

        //    var subscriptions = contracts
        //        .SelectMany(c => c.ProductAgreements, (c, pa) => new { Contract = c, ProductAgreement = pa })
        //          .SelectMany(cp => cp.Contract.PriceAgreements, (cp, pr) => new { cp.Contract, cp.ProductAgreement, PriceAgreement= pr })
        //        .SelectMany(cp => cp.Contract.ContractPersonInvolvements, (cp, cpi) => new { cp.Contract, cp.PriceAgreement, cp.ProductAgreement, cpi.Person })
        //      .GroupBy(cp => cp.Contract.Id)
        //      .Select(g => g.OrderByDescending(cp => cp.PriceAgreement.Id).FirstOrDefault())
        //        .Select(cp => new Subscription
        //        {

        //            Name = cp.ProductAgreement.ProductDefinition.Name,
        //            PriceAgreementStatusId = cp.PriceAgreement.PriceAgreementStatusId,
        //            PriceAgreementId = cp.PriceAgreement.Id,
        //            PersonId = cp.Person.Id,
        //            Status = cp.PriceAgreement.PriceAgreementStatus.Name
        //        })
        //        .ToList();

        //    return subscriptions;
        //}

        public async Task<List<Subscription>> GetSubscriptionsAsync()
        {
            // Op basis van persoonId

            var contracts = await _contractRepository.GetAllWithPropsAsync();

            var subscriptions = contracts
                .SelectMany(c => c.ProductAgreements, (c, pa) => new { Contract = c, ProductAgreement = pa })
                .SelectMany(cp => cp.Contract.PriceAgreements, (cp, pr) => new { cp.Contract, cp.ProductAgreement, PriceAgreement = pr })
                .SelectMany(cp => cp.Contract.ContractPersonInvolvements, (cp, cpi) => new { cp.Contract, cp.PriceAgreement, cp.ProductAgreement, cpi.Person })
                .Select(cp => new Subscription
                {
                   
                    ContractId= cp.Contract.Id,
                  
                    PriceAgreements = new List<PriceAgreement> // Create an empty list of price agreements
                    {
                new PriceAgreement // Add a new price agreement object
                {
                    Id = cp.PriceAgreement.Id,
                    PriceAgreementStatusId = cp.PriceAgreement.PriceAgreementStatusId,
                    ContractId = cp.Contract.Id,
                    DiscountTypeId = cp.PriceAgreement.DiscountTypeId,
                    ApproverId = cp.PriceAgreement.ApproverId,
                    Comment = cp.PriceAgreement.Comment,
                    DiscountAmount = cp.PriceAgreement.DiscountAmount,
                    StructuredMessage = cp.PriceAgreement.StructuredMessage,
                    PaymentDate = cp.PriceAgreement.PaymentDate,
                    PriceBillable = cp.PriceAgreement.PriceBillable,
                    Status = cp.PriceAgreement.PriceAgreementStatus.Name,
                }
                    },
                    PersonId = cp.Person.Id,
                    ContractDate = cp.Contract.ContractDate,
                    Status = cp.PriceAgreement.PriceAgreementStatus.Name,
                    PriceAgreementStatusId = cp.PriceAgreement.PriceAgreementStatusId,
                    PriceAgreementId = cp.PriceAgreement.Id,
                    Name = cp.ProductAgreement.ProductDefinition.Name,
                    LastName = cp.Person.LastName,
                    FirstName = cp.Person.FirstName
                })
                .ToList();

            var contractSubscriptions = subscriptions
                .GroupBy(s => s.ContractId)
                .Select(g => new Subscription
                {
                    ContractId = g.Key,
                    Name = g.Select(s => s.Name).FirstOrDefault(),
                    PersonId = g.Select(s => s.PersonId).FirstOrDefault(),
                    Status = g.Select(s => s.Status).LastOrDefault(),
                    PriceAgreementStatusId = g.Select(s => s.PriceAgreementStatusId).LastOrDefault(),
                    PriceAgreementId = g.Select(s => s.PriceAgreementId).LastOrDefault(),
                    LastName = g.Select(s => s.LastName).FirstOrDefault(),
                    FirstName = g.Select(s => s.FirstName).FirstOrDefault(),
                    ContractDate = g.Select(s => s.ContractDate).FirstOrDefault(),


                    PriceAgreements = g.SelectMany(s => s.PriceAgreements).ToList() // Flatten the list of price agreements
        })
                .ToList();

            return contractSubscriptions;
        }



    }
}

