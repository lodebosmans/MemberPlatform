using AutoMapper;
using MemberPlatformCore.Models;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.Repositories;

namespace MemberPlatformCore.Services
{
    public class OptionTypeService : IOptionTypeService
    {
        private IOptionTypeRepository _optionTypeRepository;
        private Mapper _mapper;

        public OptionTypeService(IOptionTypeRepository optionTypeRepository)
        {
            _optionTypeRepository = optionTypeRepository;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = new Mapper(config);
        }

        public async Task<OptionType> GetByIdAsync(int id)
        {
            OptionTypeEntity entity = await _optionTypeRepository.GetByIdAsync(id);
            OptionType optionType = _mapper.Map<OptionType>(entity);

            return optionType;
        }

        public async Task<List<OptionType>> GetAllAsync()
        {
            List<OptionTypeEntity> entities = (List<OptionTypeEntity>)await _optionTypeRepository.GetAllAsync();
            List<OptionType> optionTypes = new List<OptionType>();
            foreach (OptionTypeEntity entity in entities)
            {
                OptionType optionType = _mapper.Map<OptionType>(entity);
                optionTypes.Add(optionType);
            }
            return optionTypes;
        }

        public async Task<OptionType> UpdateAsync(int id, OptionType optionType)
        {
            OptionTypeEntity optionTypeEntity = _mapper.Map<OptionTypeEntity>(optionType);
            await _optionTypeRepository.Update(optionTypeEntity);

            return optionType;
        }

        public async Task<OptionType> PostAsync(OptionType optionType)
        {
            OptionTypeEntity optionTypeEntity = _mapper.Map<OptionTypeEntity>(optionType);
            await _optionTypeRepository.Insert(optionTypeEntity);

            return optionType;
        }

        public async Task<OptionType> DeleteAsync(int id)
        {
            OptionTypeEntity entity = await _optionTypeRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new ArgumentException($"OptionType with id {id} not found");
            }
            // Delete the entity from the repository
            await _optionTypeRepository.Delete(entity.Id);

            // Map the deleted entity back to an OptionType object and return it
            return _mapper.Map<OptionType>(entity);
        }
    }
}
