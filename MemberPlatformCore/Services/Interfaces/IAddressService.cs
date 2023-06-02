using MemberPlatformCore.Models;

namespace MemberPlatformCore.Services
{
    public interface IAddressService
    {
        Task<List<Address>> GetAllAsync();

        Task<Address> GetByIdAsync(int id);

        Task<Address> UpdateAsync(int id, Address address);

        Task<Address> DeleteAsync(int id);

        Task<Address> PostAsync(Address address);

        Task<List<Address>> GetTrainingFacilities();
    }
}
