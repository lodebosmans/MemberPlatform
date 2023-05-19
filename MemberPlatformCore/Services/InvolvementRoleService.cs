//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using MemberPlatformDAL.Repositories;
//using MemberPlatformDAL.Entities;
//using System.Transactions;
//using MemberPlatformCore.Models;
//using AutoMapper;

//namespace MemberPlatformCore.Services
//{
//    public class InvolvementRoleService
//    {
//        private readonly IContractRepository _contractRepository;
//        private readonly IContractPersonInvolvementRepository _personInvolvementRepository;
//        private readonly IOptionRepository _optionRepository;
//        private readonly IOptionTypeRepository _optionTypeRepository;
//        private readonly IProductDefinitionRepository _productDefinitionRepository;
//        private IMapper _mapper;

//        public InvolvementRoleService(
//            IContractRepository contractRepository,
//            IContractPersonInvolvementRepository contractPersonInvolvementRepository,
//            IOptionRepository optionRepository,
//            IOptionTypeRepository optionTypeRepository,
//            IProductDefinitionRepository productDefinitionRepository,
//            IMapper mapper)
//        {
//            _contractRepository = contractRepository;
//            _personInvolvementRepository = contractPersonInvolvementRepository;
//            _optionRepository = optionRepository;
//            _optionTypeRepository = optionTypeRepository;
//            _productDefinitionRepository = productDefinitionRepository;
//            _mapper = mapper;
//        }
//        public async Task SaveDataAsync(string involvementRoleName, Contract contract, int personId)
//        {
//            // Checks need to be update later on
//            //var exist = await _contractRepository.ContractExists(productId, personId);
//            bool exist = false;

//            if (exist == false)
//            {
//                OptionTypeEntity contractOptionTypeEntity = await _optionTypeRepository.GetOptionTypeAsync("ContractType");
//                OptionEntity contractType = await _optionRepository.GetOptionAsync(involvementRoleName, contractOptionTypeEntity.Id);

//                //OptionTypeEntity statusOptionTypeEntity = await _optionTypeRepository.GetOptionTypeAsync("Status");
//                //OptionEntity status = await _optionRepository.GetOptionAsync("Submitted", statusOptionTypeEntity.Id);

//                //OptionTypeEntity roleOptionTypeEntity = await _optionTypeRepository.GetOptionTypeAsync("Role");
//                //OptionEntity role = await _optionRepository.GetOptionAsync("Participant", roleOptionTypeEntity.Id);

//                ContractEntity contractEntity = new ContractEntity();
//                contractEntity.ContractDate = DateTime.Now;
//                contractEntity.ContractTypeId = contractType.Id;
//                ContractPersonInvolvementEntity contractPersonInvolvementEntity = new ContractPersonInvolvementEntity();
//                contractPersonInvolvementEntity.PersonId = personId;
//                contractPersonInvolvementEntity.RoleId = role.Id;

//                using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
//                try
//                {
//                    await _contractRepository.Insert(contractEntity);
//                    var savedContract = await _contractRepository.GetByIdAsync(contractEntity.Id);
//                    await _personInvolvementRepository.SaveAsync(contractPersonInvolvementEntity, savedContract.Id);

//                    transaction.Complete();
//                }
//                catch (Exception ex)
//                {
//                    throw new ApplicationException("Failed to save data.", ex);
//                }
//            }

//        }


//        //public async Task<List<Subscription>> GetAllById(int personId, int year)
//        //{
//        //    var sub = await _productDefinitionRepository.GetAllByIdAsync(personId, year);
//        //    List<Subscription> subs = new List<Subscription>();
//        //    int id = 0;
//        //    foreach (var subItem in sub)
//        //    {

//        //        var x = await _priceAgreementRepository.GetByProductPersonYear(subItem.Id, personId, year);
//        //        var status = await _optionRepository.GetByIdAsync(x[x.Count - 1].PriceAgreementStatusId);
//        //        Subscription subscription = new Subscription
//        //        {
//        //            Name = subItem.Name,
//        //            PersonId = personId,
//        //            PriceAgreementStatusId = x[x.Count - 1].PriceAgreementStatusId,
//        //            PriceAgreementId = x[x.Count - 1].Id,
//        //            Status = status.Name,
//        //            Id = id
//        //        };
//        //        //subscription.Name = subItem.Name;
//        //        //subscription.PersonId = personId;
//        //        //subscription.PriceAgreementStatusId = x[x.Count - 1].PriceAgreementStatusId;
//        //        //subscription.PriceAgreementId = x[x.Count - 1].Id;

//        //        //subscription.Status = status.Name;
//        //        //subscription.Id = id;


//        //        subs.Add(subscription);
//        //        id = id + 1;
//        //    }
//        //    return subs;
//        //}
//    }
//}
