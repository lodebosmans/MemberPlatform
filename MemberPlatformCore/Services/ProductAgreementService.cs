using AutoMapper;
using MemberPlatformCore.Models;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.Repositories;

namespace MemberPlatformCore.Services
{
    public class ProductAgreementService : IProductAgreementService
    {
        private IProductAgreementRepository _ProductAgreementRepository;
        private Mapper _mapper;

        public ProductAgreementService(IProductAgreementRepository productAgreementRepository)
        {
            _ProductAgreementRepository = productAgreementRepository;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = new Mapper(config);
        }

        public async Task<List<ProductAgreement>> GetAllAsync()
        {
            List<ProductAgreementEntity> entities = (List<ProductAgreementEntity>)await _ProductAgreementRepository.GetAllAsync();
            List<ProductAgreement> productAgreements = new List<ProductAgreement>();
            foreach (ProductAgreementEntity entity in entities)
            {
                ProductAgreement productAgreement = _mapper.Map<ProductAgreement>(entity);
                productAgreements.Add(productAgreement);
            }
            return productAgreements;
        }

        public async Task<ProductAgreement> GetByIdAsync(int id)
        {
            ProductAgreementEntity entity = await _ProductAgreementRepository.GetByIdAsync(id);
            ProductAgreement productAgreement = _mapper.Map<ProductAgreement>(entity);

            return productAgreement;
        }

        public async Task<ProductAgreement> UpdateAsync(int id, ProductAgreement productAgreement)
        {
            ProductAgreementEntity productAgreementEntity = _mapper.Map<ProductAgreementEntity>(productAgreement);
            await _ProductAgreementRepository.Update(productAgreementEntity);

            return productAgreement;
        }

        public async Task<ProductAgreement> PostAsync(ProductAgreement productAgreement)
        {
            ProductAgreementEntity productAgreementEntity = _mapper.Map<ProductAgreementEntity>(productAgreement);
            await _ProductAgreementRepository.Insert(productAgreementEntity);

            return productAgreement;
        }

        public async Task<ProductAgreement> DeleteAsync(int id)
        {
            ProductAgreementEntity entity = await _ProductAgreementRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new ArgumentException($"OptionType with id {id} not found");
            }
            // Delete the entity from the repository
            await _ProductAgreementRepository.Delete(entity.Id);

            // Map the deleted entity back to an OptionType object and return it
            return _mapper.Map<ProductAgreement>(entity);
        }
    }
}
