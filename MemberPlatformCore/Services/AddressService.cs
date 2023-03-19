using MemberPlatformCore.Models;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.Repositories;

namespace MemberPlatformCore.Services
{
    public class AddressService : IAddressService
    {
        private IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
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
                addresses.Add(address);
            }
            return addresses;
        }
    }
}
