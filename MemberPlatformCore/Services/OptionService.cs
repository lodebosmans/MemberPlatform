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
            _ = await _optionTypeRepository.GetByIdAsync((int)entity.OptionTypeId);
            Option option = _mapper.Map<Option>(entity);

            return option;
        }

        public async Task<List<Option>> GetAllAsync()
        {
            List<OptionEntity> entities = (List<OptionEntity>)await _optionRepository.GetAllAsync();
            List<Option> options = new List<Option>();
            foreach (OptionEntity entity in entities)
            {
                Option option = new Option();
                option.Id = entity.Id;
                option.Name = entity.Name;
                option.OptionType = entity.OptionType.Name;
                options.Add(option);
            }
            return options;
        }

        public async Task<Option> UpdateAsync(int id, Option option)
        {
            // Map the Option object to an OptionEntity object
            OptionEntity entity = _mapper.Map<OptionEntity>(option);
            entity.Id = id;

            // Check if the OptionType already exists based on its name
            OptionTypeEntity optionTypeEntity = await _optionTypeRepository.GetByNameAsync(option.OptionType);
            if (optionTypeEntity != null)
            {
                // Use the existing OptionType
                entity.OptionType = optionTypeEntity;
            }

            // Call the UpdateAsync method of the repository to update the entity
            entity = await _optionRepository.UpdateAsync(entity);

            // Map the updated entity back to an Option object
            Option updatedOption = _mapper.Map<Option>(entity);

            return updatedOption;
        }

        public async Task<Option> PostAsync(Option option)
        {
            // Map the Option object to an OptionEntity object
            OptionEntity entity = _mapper.Map<OptionEntity>(option);

            // Call the AddAsync method of the repository to add the entity
            entity = await _optionRepository.AddAsync(entity);

            // Map the added entity back to an Option object
            Option addedOption = _mapper.Map<Option>(entity);

            return addedOption;
        }

        public async Task<Option> DeleteAsync(int id)
        {
            OptionEntity entity = await _optionRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new ArgumentException($"Option with id {id} not found");
            }
            // Delete the entity from the repository
            await _optionRepository.DeleteAsync(entity);

            // Map the deleted entity back to an Option object and return it
            return _mapper.Map<Option>(entity);
        }
    }
}
