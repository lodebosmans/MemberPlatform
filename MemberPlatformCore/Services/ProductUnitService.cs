using AutoMapper;
using MemberPlatformCore.Models;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.Repositories;

namespace MemberPlatformCore.Services
{
    public class ProductUnitService : IProductUnitService
    {
        private IProductUnitRepository _ProductUnitRepository;
        private Mapper _mapper;

        public ProductUnitService(IProductUnitRepository productUnitRepository)
        {
            _ProductUnitRepository = productUnitRepository;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = new Mapper(config);
        }

        public async Task<ProductUnit> GetByIdAsync(int id)
        {
            ProductUnitEntity entity = await _ProductUnitRepository.GetByIdAsync(id);
            ProductUnit productUnit = _mapper.Map<ProductUnit>(entity);

            return productUnit;
        }

        public async Task<List<ProductUnit>> GetAllAsync()
        {
            List<ProductUnitEntity> entities = (List<ProductUnitEntity>)await _ProductUnitRepository.GetAllAsync();
            List<ProductUnit> productUnits = new List<ProductUnit>();
            foreach (ProductUnitEntity entity in entities)
            {
                ProductUnit productUnit = _mapper.Map<ProductUnit>(entity);
                productUnits.Add(productUnit);
            }
            return productUnits;
        }

        public async Task<ProductUnit> UpdateAsync(int id, ProductUnit productUnit)
        {
            ProductUnitEntity productUnitEntity = _mapper.Map<ProductUnitEntity>(productUnit);
            await _ProductUnitRepository.Update(productUnitEntity);

            return productUnit;
        }

        public async Task<ProductUnit> PostAsync(ProductUnit productUnit)
        {
            ProductUnitEntity productUnitEntity = _mapper.Map<ProductUnitEntity>(productUnit);
            await _ProductUnitRepository.Insert(productUnitEntity);

            return productUnit;
        }

        public async Task<ProductUnit> DeleteAsync(int id)
        {
            ProductUnitEntity entity = await _ProductUnitRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new ArgumentException($"ProductUnit with id {id} not found");
            }
            // Delete the entity from the repository
            await _ProductUnitRepository.Delete(entity.Id);

            // Map the deleted entity back to an OptionType object and return it
            return _mapper.Map<ProductUnit>(entity);
        }
    }
}
