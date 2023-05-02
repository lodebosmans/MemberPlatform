using AutoMapper;
using MemberPlatformCore.Models;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.Repositories;

namespace MemberPlatformCore.Services
{
    public class PriceAgreementService : IPriceAgreementService
    {
        private IPriceAgreementRepository _priceAgreementRepository;

        private IMapper _mapper;

        public PriceAgreementService(IPriceAgreementRepository priceAgreementRepository, IMapper mapper)
        {
            _priceAgreementRepository = priceAgreementRepository;
            _mapper = mapper;
        }

        public async Task<PriceAgreement> GetByIdAsync(int id)
        {
            PriceAgreementEntity entity = await _priceAgreementRepository.GetByIdAsync(id);
            PriceAgreement priceAgreement = _mapper.Map<PriceAgreement>(entity);

            return priceAgreement;
        }

        public async Task<List<PriceAgreement>> GetAllAsync()
        {
            List<PriceAgreementEntity> entities = (List<PriceAgreementEntity>)await _priceAgreementRepository.GetAllAsync();
            List<PriceAgreement> priceAgreements = new List<PriceAgreement>();
            foreach (PriceAgreementEntity entity in entities)
            {
                PriceAgreement priceAgreement = _mapper.Map<PriceAgreement>(entity);
                priceAgreements.Add(priceAgreement);
            }
            return priceAgreements;
        }
        public async Task<List<PriceAgreement>> GetByProductPersonYear(int contractId, int personId, int year)
        {
            List<PriceAgreementEntity> entities = (List<PriceAgreementEntity>)await _priceAgreementRepository.GetByProductPersonYear(contractId, personId, year);
            List<PriceAgreement> priceAgreements = new List<PriceAgreement>();
            foreach (PriceAgreementEntity entity in entities)
            {
                PriceAgreement priceAgreement = _mapper.Map<PriceAgreement>(entity);
                priceAgreements.Add(priceAgreement);
            }

            return priceAgreements;
        }

        public async Task<PriceAgreement> UpdateAsync(int id, PriceAgreement priceAgreement)
        {
            PriceAgreementEntity priceAgreementEntity = _mapper.Map<PriceAgreementEntity>(priceAgreement);
            await _priceAgreementRepository.Update(priceAgreementEntity);

            return priceAgreement;
        }

        public async Task<PriceAgreement> PostAsync(PriceAgreement priceAgreement)
        {
            PriceAgreementEntity priceAgreementEntity = _mapper.Map<PriceAgreementEntity>(priceAgreement);
            await _priceAgreementRepository.Insert(priceAgreementEntity);

            return priceAgreement;
        }

        public async Task<PriceAgreement> DeleteAsync(int id)
        {
            PriceAgreementEntity entity = await _priceAgreementRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new ArgumentException($"PriceAgreement with id {id} not found");
            }
            // Delete the entity from the repository
            await _priceAgreementRepository.Delete(entity.Id);

            // Map the deleted entity back to an OptionType object and return it
            return _mapper.Map<PriceAgreement>(entity);
        }
    }
}
