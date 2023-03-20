using AutoMapper;
using MemberPlatformCore.Models;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.Repositories;

namespace MemberPlatformCore.Services
{
    public class OptionService : IOptionSevice
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

        public async Task<Option> GetByIDAsync(int id)
        {
            OptionEntity entity = await _optionRepository.GetByIDAsync(id);

            Option option = _mapper.Map<Option>(entity);

            return option;
        }
    }
}
