using AutoMapper;
using MemberPlatformCore.Models;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.Repositories;

namespace MemberPlatformCore.Services
{
    public class OptionService : IOptionService
    {
        private IOptionRepository _optionRepository;
        private IOptionTypeRepository _optionTypeRepository;
        private Mapper _mapper;

        public OptionService(IOptionRepository optionRepository, IOptionTypeRepository optionTypeRepository)
        {
            _optionRepository = optionRepository;
            _optionTypeRepository = optionTypeRepository;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = new Mapper(config);
        }

        public async Task<Option> GetByIdAsync(int id)
        {
            OptionEntity entity = await _optionRepository.GetByIdAsync(id);
            Option option = _mapper.Map<Option>(entity);

            return option;
        }

        public async Task<List<Option>> GetAllAsync()
        {
            List<OptionEntity> entities = (List<OptionEntity>)await _optionRepository.GetAllAsync();
            List<Option> options = new List<Option>();
            foreach (OptionEntity entity in entities)
            {
                Option option = _mapper.Map<Option>(entity);
                options.Add(option);
            }
            return options;
        }

        public async Task<Option> UpdateAsync(int id, Option option)
        {
            OptionEntity optionEntity = _mapper.Map<OptionEntity>(option);
            await _optionRepository.Update(optionEntity);

            return option;
        }

        public async Task<Option> PostAsync(Option option)
        {
            OptionEntity optionEntity = _mapper.Map<OptionEntity>(option);
            await _optionRepository.Insert(optionEntity);

            return option;
        }

        public async Task<Option> DeleteAsync(int id)
        {
            OptionEntity entity = await _optionRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new ArgumentException($"Option with id {id} not found");
            }
            // Delete the entity from the repository
            await _optionRepository.Delete(entity.Id);

            // Map the deleted entity back to an OptionType object and return it
            return _mapper.Map<Option>(entity);
        }
    }
}
