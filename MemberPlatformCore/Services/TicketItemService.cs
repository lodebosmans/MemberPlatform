using AutoMapper;
using MemberPlatformCore.Models;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.Repositories;

namespace MemberPlatformCore.Services
{
    public class TicketItemService : ITicketItemService
    {
        private ITicketItemRepository _ticketItemRepository;
        private Mapper _mapper;

        public TicketItemService(ITicketItemRepository ticketItemRepository)
        {
            _ticketItemRepository = ticketItemRepository;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = new Mapper(config);
        }

        public async Task<List<TicketItem>> GetAllAsync()
        {
            List<TicketItemEntity> entities = (List<TicketItemEntity>)await _ticketItemRepository.GetAllAsync();
            List<TicketItem> ticketItems = new List<TicketItem>();
            foreach (TicketItemEntity entity in entities)
            {
                TicketItem ticketItem = _mapper.Map<TicketItem>(entity);
                ticketItems.Add(ticketItem);
            }
            return ticketItems;
        }

        public async Task<TicketItem> GetByIdAsync(int id)
        {
            TicketItemEntity entity = await _ticketItemRepository.GetByIdAsync(id);
            TicketItem ticketItem = _mapper.Map<TicketItem>(entity);

            return ticketItem;
        }

        public async Task<TicketItem> UpdateAsync(int id, TicketItem ticketItem)
        {
            TicketItemEntity ticketItemEntity = _mapper.Map<TicketItemEntity>(ticketItem);
            await _ticketItemRepository.Update(ticketItemEntity);

            return ticketItem;
        }

        public async Task<TicketItem> PostAsync(TicketItem ticketItem)
        {
            TicketItemEntity ticketItemEntity = _mapper.Map<TicketItemEntity>(ticketItem);
            await _ticketItemRepository.Insert(ticketItemEntity);

            return ticketItem;
        }

        public async Task<TicketItem> DeleteAsync(int id)
        {
            TicketItemEntity entity = await _ticketItemRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new ArgumentException($"OptionType with id {id} not found");
            }
            // Delete the entity from the repository
            await _ticketItemRepository.Delete(entity.Id);

            // Map the deleted entity back to an OptionType object and return it
            return _mapper.Map<TicketItem>(entity);
        }
    }
}
