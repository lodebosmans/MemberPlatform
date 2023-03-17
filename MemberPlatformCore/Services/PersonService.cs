using MemberPlatformCore.Models;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.Repositories;

namespace MemberPlatformCore.Services
{
    public class PersonService : IPersonService
    {
        private IPersonRepository _personRepository;
        private IAddressRepository _addressRepository;

        public PersonService(IPersonRepository personRepository, IAddressRepository addressRepository)
        {
            _personRepository = personRepository;
            _addressRepository = addressRepository;
        }
        public async Task<Person> GetPersonAsync(int id)
        {
            PersonEntity entity = await _personRepository.GetByIDAsync(id);
            Person person = new Person();
            //Todo automapper
            person.Id = entity.Id;
            person.DateOfBirth = entity.DateOfBirth;
            person.EmailAddress = entity.EmailAddress;
            person.FirstName = entity.FirstName;
            person.Gender = entity.Gender;
            person.IdentityNumber = entity.IdentityNumber;
            person.InsuranceCompany = entity.InsuranceCompany;
            person.LastName = entity.LastName;
            person.MobilePhone = entity.MobilePhone;
            person.PrivacyApproval = entity.PrivacyApproval;
            person.PostalCode = entity.Address.PostalCode;
            person.Street = "Kerkstraat";

            return person; 
        }

        //public async Task<List<Person>> GetAllWithAddressAsync()
        //{
        //    PersonEntity entity = (PersonEntity)await _personRepository.GetAllWithAddressAsync();
        //    Person person = new Person();
        //    person.Id = entity.Id;
        //    person.PostalCode = entity.Address.PostalCode;
        //    person.Country = entity.Address.Country;


        //    return person;
        //}
        public async Task<List<Person>> GetAllWithAddressAsync()
        {
            List<PersonEntity> entities = (List<PersonEntity>)await _personRepository.GetAllWithAddressAsync();
            List<Person> people = new List<Person>();
            foreach (PersonEntity entity in entities)
            {
                Person person = new Person();
                person.Id = entity.Id;
                person.FirstName= entity.FirstName;
                person.LastName= entity.LastName;
                person.PrivacyApproval= entity.PrivacyApproval;
                person.InsuranceCompany= entity.InsuranceCompany;
                person.IdentityNumber= entity.IdentityNumber;
                person.MobilePhone= entity.MobilePhone;
                person.Gender= entity.Gender;
                person.DateOfBirth = entity.DateOfBirth;
                person.EmailAddress = entity.EmailAddress;
                person.PostalCode = entity.Address.PostalCode;
                person.Country = entity.Address.Country;
                person.City = entity.Address.City;
                person.Street= entity.Address.Street;
                person.Box= entity.Address.Box;
                person.Number= entity.Address.Number;

                people.Add(person);
            }

            return people;
        }


    }
}
