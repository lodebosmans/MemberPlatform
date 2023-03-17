using MemberPlatformCore.Models;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.Repositories;

namespace MemberPlatformCore.Services
{
    public class PersonService : IPersonService
    {
        private IPersonRepository _personRepository;
        // private IAddressRepository _addressRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> GetPersonAsync(int id)
        {
            PersonEntity entity = await _personRepository.GetByIDAsync(id);
            Person person = new Person();
            //Todo automapper
            person.Id = entity.Id;
            person.FirstName = entity.FirstName;
            person.LastName = entity.LastName;
            person.PrivacyApproval = entity.PrivacyApproval;
            person.Street = "Kerkstraat";

            return person;

        }
    }
}