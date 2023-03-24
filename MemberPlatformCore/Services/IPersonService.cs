using MemberPlatformCore.Models;

namespace MemberPlatformCore.Services
{
    public interface IPersonService
    {
        Task<Person> GetPersonAsync(int id);

        Task<List<Person>> GetAllWithAddressAsync();

        Task UpdateAsync(int id, Person person);
        Task DeleteAsync(int id);
    }
}
