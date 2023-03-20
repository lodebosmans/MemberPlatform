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
            List<OptionTypeEntity> entities = await _optionTypeRepository.GetAllAsync();
            List<OptionType> optionTypes = new List<OptionType>();
            foreach (OptionTypeEntity entity in entities)
            {
                OptionType optionType = new OptionType();
                optionType.Id = entity.Id;
                optionType.Name = entity.Name;
                optionTypes.Add(optionType);
            }
            return optionTypes;
        }

        public async Task<OptionType> UpdateAsync(int id, OptionType optionType)
        {
            // Map the OptionType object to an OptionTypeEntity object
            OptionTypeEntity entity = _mapper.Map<OptionTypeEntity>(optionType);
            entity.Id = id;

            // Call the UpdateAsync method of the repository to update the entity
            entity = await _optionTypeRepository.UpdateAsync(entity);

            // Map the updated entity back to an OptionType object
            OptionType updatedOptionType = _mapper.Map<OptionType>(entity);

            return updatedOptionType;
        }

        //public async Task<OptionType> UpdateAsync(int id, OptionType optionType)
        //{
        //    if (id != optionType.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _optionTypeRepository.UpdateAsync(optionType);

        //    try
        //    {
        //        await _optionTypeRepository.SaveAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OptionTypeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    return NoContent();
    }
}
