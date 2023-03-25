using AutoMapper;
using MemberPlatformCore.Models;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.Repositories;

namespace MemberPlatformCore.Services
{
    public class SalesItemService : ISalesItemService
    {
        private ISalesItemRepository _salesItemRepository;
        private Mapper _mapper;

        public SalesItemService(ISalesItemRepository salesItemRepository)
        {
            _salesItemRepository = salesItemRepository;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = new Mapper(config);
        }

        public async Task<List<SalesItem>> GetAllAsync()
        {
            List<SalesItemEntity> entities = (List<SalesItemEntity>)await _salesItemRepository.GetAllAsync();
            List<SalesItem> salesItems = new List<SalesItem>();
            foreach (SalesItemEntity entity in entities)
            {
                SalesItem salesItem = _mapper.Map<SalesItem>(entity);
                salesItems.Add(salesItem);
            }
            return salesItems;
        }

        public async Task<SalesItem> GetByIdAsync(int id)
        {
            SalesItemEntity entity = await _salesItemRepository.GetByIdAsync(id);
            SalesItem salesItem = _mapper.Map<SalesItem>(entity);

            return salesItem;
        }

        public async Task<SalesItem> UpdateAsync(int id, SalesItem salesItem)
        {
            SalesItemEntity salesItemEntity = _mapper.Map<SalesItemEntity>(salesItem);
            await _salesItemRepository.Update(salesItemEntity);

            return salesItem;
        }

        public async Task<SalesItem> PostAsync(SalesItem salesItem)
        {
            SalesItemEntity salesItemEntity = _mapper.Map<SalesItemEntity>(salesItem);
            await _salesItemRepository.Insert(salesItemEntity);

            return salesItem;
        }

        public async Task<SalesItem> DeleteAsync(int id)
        {
            SalesItemEntity entity = await _salesItemRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new ArgumentException($"SalesItem with id {id} not found");
            }
            // Delete the entity from the repository
            await _salesItemRepository.Delete(entity.Id);

            // Map the deleted entity back to an OptionType object and return it
            return _mapper.Map<SalesItem>(entity);
        }
    }
}
