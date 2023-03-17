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
    }
}
