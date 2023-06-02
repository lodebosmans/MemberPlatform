using MemberPlatformCore.Models;

namespace MemberPlatformCore.Services
{
    public interface IPersonService
    {
        Task<Person> GetPersonAsync(int id);

        Task<List<Person>> GetAllWithAddressAsync();

        //Task UpdateAsync(int id, Person person);
        Task DeleteAsync(int id);

        Task<Person> PostAsync(Person person);

        Task<Person> UpdateAsync(int id, Person person);

        Task<List<Person>> GetPersonByEmailAddressAsync(string emailAddress);

        Task<List<int>> GetPersonIdsAsync(string emailAddress);
    }
}
