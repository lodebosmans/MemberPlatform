using MemberPlatformCore.Models;

namespace MemberPlatformCore.Services
{
    public interface IPersonService1
    {
        Task<Person> CreatePersonAsync(Person person);
        Task DeleteAsync(int id);
        Task<List<Person>> GetAllWithAddressAsync();
        Task<Person> GetPersonAsync(int id);
        Task UpdateAsync(int id, Person person);
    }
}