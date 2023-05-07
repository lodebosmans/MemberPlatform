using AutoMapper;
using MemberPlatformCore.Models;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.Repositories;

namespace MemberPlatformCore.Services
{
    public class ContractService : IContractService
    {
        private IContractRepository _contractRepository;
        private IMapper _mapper;

        public ContractService(IContractRepository contractRepository, IMapper mapper)
        {
            _contractRepository = contractRepository;
            _mapper = mapper;
        }

        public async Task<List<Contract>> GetAllAsync()
        {
            List<ContractEntity> entities = (List<ContractEntity>)await _contractRepository.GetAllAsync();
            List<Contract> contracts = new List<Contract>();
            foreach (ContractEntity entity in entities)
            {
                Contract contract = _mapper.Map<Contract>(entity);
                contracts.Add(contract);
            }
            return contracts;
        }

        public async Task<Contract> GetByIdAsync(int id)
        {
            ContractEntity entity = await _contractRepository.GetByIdAsync(id);
            Contract contract = _mapper.Map<Contract>(entity);

            return contract;
        }

        public async Task<Contract> UpdateAsync(int id, Contract contract)
        {
            ContractEntity contractEntity = _mapper.Map<ContractEntity>(contract);
            await _contractRepository.Update(contractEntity);

            return contract;
        }

        public async Task<Contract> PostAsync(Contract optionType)
        {
            ContractEntity contractEntity = _mapper.Map<ContractEntity>(optionType);
            await _contractRepository.Insert(contractEntity);

            return optionType;
        }

        public async Task<Contract> DeleteAsync(int id)
        {
            ContractEntity entity = await _contractRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new ArgumentException($"OptionType with id {id} not found");
            }
            // Delete the entity from the repository
            await _contractRepository.Delete(entity.Id);

            // Map the deleted entity back to an OptionType object and return it
            return _mapper.Map<Contract>(entity);
        }

        public async Task<bool> ContractExists(int productId, int personId)
        {
            return await _contractRepository.ContractExists(productId, personId);
       

        }

    }
}
