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


        //public async Task<Person> UpdateAsync(int id, Person person)
        //{
        //    // Map the Person object to a PersonEntity object
        //    PersonEntity entity = _mapper.Map<PersonEntity>(person);
        //    entity.Id = id;

        //    //// Check if the AddressType already exists based on its name
        //    //OptionEntity optionEntity optionEntity = await _optionRepository.GetByIdAsync(person.address.AddressTypeId);
        //    //if (addressEntity == null)
        //    //{
        //    //    //// If the AddressType doesn't exist, create a new one
        //    //    //AddressTypeEntity newAddressTypeEntity = new AddressTypeEntity { Name = person.AddressType };
        //    //    //addressTypeEntity = await _addressTypeRepository.AddAsync(newAddressTypeEntity);
        //    //    throw new ArgumentException("AddressType not found");
        //    //}

        //    //// Set the AddressTypeId on the AddressEntity
        //    //entity.Address.AddressType = addressEntity.AddressType;

        //    // Call the UpdateAsync method of the repository to update the entity
        //    entity = await _personRepository.UpdateAsync(entity);

        //    // Map the updated entity back to a Person object
        //    Person updatedPerson = _mapper.Map<Person>(entity);

        //    return updatedPerson;
        //}
        public async Task<Person> UpdateAsync(int id, Person person)
        {
            // Map the Person object to an PersonEntity object
            PersonEntity entity = _mapper.Map<PersonEntity>(person);
            entity.Id = id;

            // Call the UpdateAsync method of the repository to update the Person entity
            entity = await _personRepository.UpdateAsync(entity);

            // Map the updated entity back to a Person object
            Person updatedPerson = _mapper.Map<Person>(entity);

            return updatedPerson;
        }


        public async Task<Person> DeleteAsync(int id)
        {
            PersonEntity entity = await _personRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new ArgumentException($"Person with id {id} not found");
            }
            // Delete the entity from the repository
            await _personRepository.DeleteAsync(entity);

            // Map the deleted entity back to an OptionType object and return it
            return _mapper.Map<Person>(entity);
        }

    }
}


