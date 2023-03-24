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
            List<AddressEntity> entities = (List<AddressEntity>)await _addressRepository.GetAllWithAddressTypeAsync();
            List<Address> addresses = new List<Address>();
            foreach (AddressEntity entity in entities)
            {

                Address address = _mapper.Map<Address>(entity);
                addresses.Add(address);
            }
            return addresses;
        }

        public async Task<Address> GetByIdAsync(int id)
        {
            AddressEntity entity = await _addressRepository.GetAddressWithAddressType(id);
            Address address = _mapper.Map<Address>(entity);

            return address;
        }

        public async Task<Address> UpdateAsync(int id, Address address)
        {
            AddressEntity addressEntity = _mapper.Map<AddressEntity>(address);
            await _addressRepository.Update(addressEntity);

            return address;
        }

        public async Task<Address> PostAsync(Address address)
        {
            AddressEntity addressEntity = _mapper.Map<AddressEntity>(address);
            await _addressRepository.Insert(addressEntity);

            return address;
        }


        public async Task<Address> DeleteAsync(int id)
        {
            AddressEntity entity = await _addressRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new ArgumentException($"Address with id {id} not found");
            }
            // Delete the entity from the repository
            await _addressRepository.Delete(entity.Id);

            // Map the deleted entity back to an OptionType object and return it
            return _mapper.Map<Address>(entity);
        }

    }
}
