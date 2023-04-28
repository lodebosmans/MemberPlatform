using AutoMapper;
using MemberPlatformCore.Models;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.Repositories;
using System.Transactions;

namespace MemberPlatformCore.Services
{
    public class PersonService : IPersonService
    {
        private IPersonRepository _personRepository;
        private IAddressRepository _addressRepository;
        private IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<Person> GetPersonAsync(int id)
        {
            PersonEntity entity = await _personRepository.GetByIdAsync(id);
            Person person = _mapper.Map<Person>(entity);

            return person;
        }

        public async Task<int?> GetPersonByEmailAddressAsync(string emailAddress)
        {
            PersonEntity entity = await _personRepository.GetByEmailAddressAsync(emailAddress);
            Person person = _mapper.Map<Person>(entity);

            if (person == null)
            {
                return null;
            }
            else
            {
                return person.Id;
            }
        }

        public async Task<List<Person>> GetAllWithAddressAsync()
        {
            List<PersonEntity> entities = (List<PersonEntity>)await _personRepository.GetAllWithAddressAsync();
            List<Person> people = new List<Person>();
            foreach (PersonEntity entity in entities)
            {
                Person person = _mapper.Map<Person>(entity);
                people.Add(person);
            }

            return people;
        }

        public async Task<Person> UpdateAsync(int id, Person person)
        {
            // Map the Person object to an PersonEntity object
            PersonEntity entity = _mapper.Map<PersonEntity>(person);
            await _personRepository.Update(entity);

            return person;

        }

        public async Task<Person> PostAsync(Person person)
        {
            // Map Person object to PersonEntity object
            PersonEntity personEntity = _mapper.Map<PersonEntity>(person);

            // Map Address object to AddressEntity object
            AddressEntity addressEntity = _mapper.Map<AddressEntity>(personEntity.Address);

            using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            {
                try
                {
                    // Add address to address repository
                    await _addressRepository.Insert(addressEntity);
                    // Get address again

                    // Add id to person
                    
                    // Add person to person repository
                    await _personRepository.Insert(personEntity);

                    // Commit the transaction
                    transaction.Complete();

                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Failed to save data.", ex);
                }

                return person;
            } 
        }

        public async Task DeleteAsync(int id)
        {
            PersonEntity entity = await _personRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new ArgumentException($"Person with id {id} not found");
            }
            // Delete the entity from the repository
            await _personRepository.Delete(entity.Id);
        }
    }
}
