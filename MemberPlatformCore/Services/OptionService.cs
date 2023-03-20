using AutoMapper;
using MemberPlatformCore.Models;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.Repositories;

namespace MemberPlatformCore.Services
{
    public class OptionService : IOptionService
    {
        private IOptionRepository _optionRepository;
        private Mapper _mapper;

        public OptionService(IOptionRepository optionRepository)
        {
            _optionRepository = optionRepository;

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
                Option option = new Option();
                option.Id = entity.Id;
                option.Name = entity.Name;
                options.Add(option);
            }
            return options;
        }
    }
}
