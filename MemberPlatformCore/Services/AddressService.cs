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

        public async Task<Address> GetByIdAsync(int id)
        {
            AddressEntity entity = await _addressRepository.GetByIdAsync(id);
            _ = await _optionRepository.GetByIdAsync(entity.AddressTypeId);
            Address address = _mapper.Map<Address>(entity);

            return address;
        }

        public async Task<Address> UpdateAsync(int id, Address address)
        {
            // Map the Address object to an AddressEntity object
            AddressEntity entity = _mapper.Map<AddressEntity>(address);
            entity.Id = id;

            // Check if the AddressType already exists based on its name
            OptionEntity optionEntity = await _optionRepository.GetByNameAsync(address.AddressType);
            if (optionEntity == null)
            {
                throw new ArgumentException("AddressType not found");
            }

            // Use the existing AddressType
            entity.AddressType = optionEntity;

            // Call the UpdateAsync method of the repository to update the entity
            entity = await _addressRepository.UpdateAsync(entity);

            // Map the updated entity back to an Address object
            Address updatedAddress = _mapper.Map<Address>(entity);

            return updatedAddress;
        }

        public async Task<Address> PostAsync(Address address)
        {
            // Map the Address object to an AddressEntity object
            AddressEntity entity = _mapper.Map<AddressEntity>(address);

            // Check if the AddressType already exists based on its name
            OptionEntity optionEntity = await _optionRepository.GetByNameAsync(address.AddressType);
            if (optionEntity == null)
            {
                throw new ArgumentException("AddressType not found");
            }

            // Use the existing AddressType
            entity.AddressType = optionEntity;

            // Call the AddAsync method of the repository to add the entity
            entity = await _addressRepository.AddAsync(entity);

            // Map the added entity back to an Address object
            Address addedAddress = _mapper.Map<Address>(entity);

            return addedAddress;
        }


        public async Task<Address> DeleteAsync(int id)
        {
            AddressEntity entity = await _addressRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new ArgumentException($"Address with id {id} not found");
            }
            // Delete the entity from the repository
            await _addressRepository.DeleteAsync(entity);

            // Map the deleted entity back to an OptionType object and return it
            return _mapper.Map<Address>(entity);
        }

    }
}
