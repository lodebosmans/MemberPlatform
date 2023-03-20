using AutoMapper;
using MemberPlatformCore.Models;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.Repositories;

namespace MemberPlatformCore.Services
{
    public class AddressService : IAddressService
    {
        private IAddressRepository _addressRepository;
        private IOptionRepository _optionRepository;
        private Mapper _mapper;

        public AddressService(IAddressRepository addressRepository, IOptionRepository optionRepository)
        {
            _addressRepository = addressRepository;
            _optionRepository = optionRepository;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = new Mapper(config);
        }

        public async Task<List<Address>> GetAllAsync()
        {
            List<AddressEntity> entities = (List<AddressEntity>)await _addressRepository.GetAllAsync();
            List<Address> addresses = new List<Address>();
            foreach (AddressEntity entity in entities)
            {
                Address address = new Address();
                address.Id = entity.Id;
                address.Name = entity.Name;
                address.Street = entity.Street;
                address.City = entity.City;
                address.PostalCode = entity.PostalCode;
                address.Country = entity.Country;
                address.Number = entity.Number;
                address.Box = entity.Box;
                address.AddressType = entity.AddressType.Name;
                addresses.Add(address);
            }
            return addresses;
        }

        public async Task<Address> GetByIDAsync(int id)
        {
            AddressEntity entity = await _addressRepository.GetByIDAsync(id);
            _ = await _optionRepository.GetByIDAsync(entity.AddressTypeId);
            Address address = _mapper.Map<Address>(entity);

            return address;
        }
    }
}
