using AutoMapper;
using MemberPlatformCore.Models;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.Repositories;

namespace MemberPlatformCore.Services
{
    public class ProductDefinitionService : IProductDefinitionService
    {
        private IProductDefinitionRepository _productDefinitionRepository;
        private Mapper _mapper;

        public ProductDefinitionService(IProductDefinitionRepository productDefinitionRepository)
        {
            _productDefinitionRepository = productDefinitionRepository;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = new Mapper(config);
        }

        public async Task<List<ProductDefinition>> GetAllAsync()
        {
            List<ProductDefinitionEntity> entities = (List<ProductDefinitionEntity>)await _productDefinitionRepository.GetAllAsync();
            List<ProductDefinition> productDefinitions = new List<ProductDefinition>();
            foreach (ProductDefinitionEntity entity in entities)
            {
                ProductDefinition productDefinition = _mapper.Map<ProductDefinition>(entity);
                productDefinitions.Add(productDefinition);
            }
            return productDefinitions;
        }

        public async Task<ProductDefinition> GetByIdAsync(int id)
        {
            ProductDefinitionEntity entity = await _productDefinitionRepository.GetByIdAsync(id);
            ProductDefinition productDefinition = _mapper.Map<ProductDefinition>(entity);

            return productDefinition;
        }

        public async Task<ProductDefinition> UpdateAsync(int id, ProductDefinition productDefinition)
        {
            ProductDefinitionEntity productDefinitionEntity = _mapper.Map<ProductDefinitionEntity>(productDefinition);
            await _productDefinitionRepository.Update(productDefinitionEntity);

            return productDefinition;
        }

        public async Task<ProductDefinition> PostAsync(ProductDefinition productDefinition)
        {
            ProductDefinitionEntity productDefinitionEntity = _mapper.Map<ProductDefinitionEntity>(productDefinition);
            await _productDefinitionRepository.Insert(productDefinitionEntity);

            return productDefinition;
        }

        public async Task<ProductDefinition> DeleteAsync(int id)
        {
            ProductDefinitionEntity entity = await _productDefinitionRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new ArgumentException($"OptionType with id {id} not found");
            }
            // Delete the entity from the repository
            await _productDefinitionRepository.Delete(entity.Id);

            // Map the deleted entity back to an OptionType object and return it
            return _mapper.Map<ProductDefinition>(entity);
        }
    }
}
