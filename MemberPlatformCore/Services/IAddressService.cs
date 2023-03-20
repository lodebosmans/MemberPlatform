using MemberPlatformCore.Models;

namespace MemberPlatformCore.Services
{
    public interface IAddressService
    {
        Task<List<Address>> GetAllAsync();

        Task<Address> GetByIDAsync(int id);
    }
}
