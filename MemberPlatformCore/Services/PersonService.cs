using AutoMapper;
using MemberPlatformCore.Models;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.Repositories;

namespace MemberPlatformCore.Services
{
    public class PersonService : IPersonService
    {
        private IPersonRepository _personRepository;
        private IAddressRepository _addressRepository;
        private IOptionRepository _optionRepository;
        private Mapper _mapper;

        public PersonService(IPersonRepository personRepository, IAddressRepository addressRepository, IOptionRepository optionRepository)
        {
            _personRepository = personRepository;
            _addressRepository = addressRepository;
            _optionRepository = optionRepository;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = new Mapper(config);
        }

        public async Task<Person> GetPersonAsync(int id)
        {
            PersonEntity entity = await _personRepository.GetByIdAsync(id);
            _ = await _addressRepository.GetByIdAsync(entity.AddressId);
            _ = await _optionRepository.GetByIdAsync(entity.Address.AddressTypeId);
            Person person = _mapper.Map<Person>(entity);

            return person;
        }

        public async Task<List<Person>> GetAllWithAddressAsync()
        {
            List<PersonEntity> entities = (List<PersonEntity>)await _personRepository.GetAllWithAddressAsync();
            List<Person> people = new List<Person>();
            foreach (PersonEntity entity in entities)
            {
                Person person = new Person();
                person.Id = entity.Id;
                person.FirstName = entity.FirstName;
                person.LastName = entity.LastName;
                person.PrivacyApproval = entity.PrivacyApproval;
                person.InsuranceCompany = entity.InsuranceCompany;
                person.IdentityNumber = entity.IdentityNumber;
                person.MobilePhone = entity.MobilePhone;
                person.Gender = entity.Gender;
                person.DateOfBirth = entity.DateOfBirth;
                person.EmailAddress = entity.EmailAddress;
                person.PostalCode = entity.Address.PostalCode;
                person.Country = entity.Address.Country;
                person.City = entity.Address.City;
                person.Street = entity.Address.Street;
                person.Box = entity.Address.Box;
                person.Number = entity.Address.Number;
                person.AddressType = entity.Address.AddressType.Name;

                people.Add(person);
            }

            return people;
        }

        public async Task<Person> UpdateAsync(int id, Person person)
        {
            // Map the Person object to an PersonEntity object
            PersonEntity entity = _mapper.Map<PersonEntity>(person);
            entity.Id = id;

            // Check if the AddressType already exists based on its name
            OptionEntity optionEntity = await _optionRepository.GetByNameAsync(person.AddressType);
            if (optionEntity == null)
            {
                throw new ArgumentException("AddressType not found");
            }

            // Use the existing AddressType
            entity.Address.AddressType = optionEntity;
            // Call the UpdateAsync method of the repository to update the entity
            entity = await _personRepository.UpdateAsync(entity);

            // Map the updated entity back to an OptionType object
            Person updatedPerson = _mapper.Map<Person>(entity);

            return updatedPerson;
        }
    }
}

//public async Task<Person> GetPersonAsync(int id)
//{
//    PersonEntity entity = await _personRepository.GetByIDAsync(id);
//    Person person = new Person();
//    //Todo automapper
//    person.Id = entity.Id;
//    person.DateOfBirth = entity.DateOfBirth;
//    person.EmailAddress = entity.EmailAddress;
//    person.FirstName = entity.FirstName;
//    person.Gender = entity.Gender;
//    person.IdentityNumber = entity.IdentityNumber;
//    person.InsuranceCompany = entity.InsuranceCompany;
//    person.LastName = entity.LastName;
//    person.MobilePhone = entity.MobilePhone;
//    person.PrivacyApproval = entity.PrivacyApproval;
//    person.PostalCode = entity.Address.PostalCode;
//    person.Street = "Kerkstraat";

//    return person;
//}
//public async Task<List<Person>> GetAllWithAddressAsync()
//{
//    PersonEntity entity = (PersonEntity)await _personRepository.GetAllWithAddressAsync();
//    Person person = new Person();
//    person.Id = entity.Id;
//    person.PostalCode = entity.Address.PostalCode;
//    person.Country = entity.Address.Country;

//    return person;
//}
