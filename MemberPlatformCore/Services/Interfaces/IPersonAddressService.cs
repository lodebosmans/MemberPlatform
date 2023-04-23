using MemberPlatformCore.Models;

namespace MemberPlatformCore.Services
{
    public interface IPersonAddressService
    {
        Task SaveDataAsync(Person person, Address address);
    }
}