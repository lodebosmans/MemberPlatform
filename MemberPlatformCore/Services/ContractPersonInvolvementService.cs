using AutoMapper;
using MemberPlatformCore.Models;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.Repositories;

namespace MemberPlatformCore.Services
{
    public class ContractPersonInvolvementService : IContractPersonInvolvementService
    {
        private IContractPersonInvolvementRepository _contractPersonInvolvementRepository;
        private IMapper _mapper;

        public ContractPersonInvolvementService(IContractPersonInvolvementRepository contractPersonInvolvementRepository, IMapper mapper)
        {
            _contractPersonInvolvementRepository = contractPersonInvolvementRepository;
            _mapper = mapper;
        }

        public async Task<ContractPersonInvolvement> GetByIdAsync(int id)
        {
            ContractPersonInvolvementEntity entity = await _contractPersonInvolvementRepository.GetByIdAsync(id);
            ContractPersonInvolvement option = _mapper.Map<ContractPersonInvolvement>(entity);

            return option;
        }

        public async Task<List<ContractPersonInvolvement>> GetAllAsync()
        {
            List<ContractPersonInvolvementEntity> entities = (List<ContractPersonInvolvementEntity>)await _contractPersonInvolvementRepository.GetAllAsync();
            List<ContractPersonInvolvement> contractPersonInvolvements = new List<ContractPersonInvolvement>();
            foreach (ContractPersonInvolvementEntity entity in entities)
            {
                ContractPersonInvolvement contractPersonInvolvement = _mapper.Map<ContractPersonInvolvement>(entity);
                contractPersonInvolvements.Add(contractPersonInvolvement);
            }
            return contractPersonInvolvements;
        }

        public async Task<ContractPersonInvolvement> UpdateAsync(int id, ContractPersonInvolvement contractPersonInvolvement)
        {
            ContractPersonInvolvementEntity contractPersonInvolvementEntity = _mapper.Map<ContractPersonInvolvementEntity>(contractPersonInvolvement);
            await _contractPersonInvolvementRepository.Update(contractPersonInvolvementEntity);

            return contractPersonInvolvement;
        }

        public async Task<ContractPersonInvolvement> PostAsync(ContractPersonInvolvement contractPersonInvolvement)
        {
            ContractPersonInvolvementEntity contractPersonInvolvementEntity = _mapper.Map<ContractPersonInvolvementEntity>(contractPersonInvolvement);
            await _contractPersonInvolvementRepository.Insert(contractPersonInvolvementEntity);

            return contractPersonInvolvement;
        }

        public async Task<ContractPersonInvolvement> DeleteAsync(int id)
        {
            ContractPersonInvolvementEntity entity = await _contractPersonInvolvementRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new ArgumentException($"Option with id {id} not found");
            }
            // Delete the entity from the repository
            await _contractPersonInvolvementRepository.Delete(entity.Id);

            // Map the deleted entity back to an OptionType object and return it
            return _mapper.Map<ContractPersonInvolvement>(entity);
        }
    }
}
