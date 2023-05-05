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
        private IOptionRepository _optionRepository;
        private IMapper _mapper;

        public PersonService(IPersonRepository personRepository, 
            IAddressRepository addressRepository,
            IOptionRepository optionRepository,
            IMapper mapper)
        {
            _personRepository = personRepository;
            _addressRepository = addressRepository;
            _optionRepository = optionRepository;
            _mapper = mapper;
        }

        public async Task<Person> GetPersonAsync(int id)
        {
            PersonEntity entity = await _personRepository.GetByIdAsync(id);
            Person person = _mapper.Map<Person>(entity);

            return person;
        }

        public async Task<List<int>> GetPersonIdsAsync(string emailAddress)
        {
            PersonEntity personEntity = await _personRepository.GetByEmailAddressAsync(emailAddress);

            if (personEntity == null)
            {
                return null;
            }
            else
            {
                // Create a list for the person IDs we need to collect.
                List<int> ids = new List<int>();

                // Get the IDs of the parent and add it to the list
                ids.Add(personEntity.Id);

                // Get the IDs of the children, if any, and add them to the list
                if (personEntity.Children != null)
                {
                    foreach (PersonEntity child in personEntity.Children)
                    {
                        ids.Add(child.Id);
                    }
                }
                return ids;
            }
        }

        public async Task<List<Person>> GetPersonByEmailAddressAsync(string emailAddress)
        {
            List<int> ids = await GetPersonIdsAsync(emailAddress);

            if (ids == null)
            {
                return null;
            }
            else
            {
                // 
                List<Person> people = new List<Person>();

                // Loop over the collected IDs
                foreach (int id in ids) 
                {
                    // Fetch the person object with that ID
                    PersonEntity personEntity_bis = await _personRepository.GetByIdAsync(id);
                    Person person = _mapper.Map<Person>(personEntity_bis);
                    people.Add(person);
                }

                return people;
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
            PersonEntity personEntity = _mapper.Map<PersonEntity>(person);
            // Get the Option for a residential address
            OptionEntity optionEntity = await _optionRepository.GetOptionAsync("Residential");
            personEntity.Address.AddressTypeId = optionEntity.Id;
            personEntity.Address.AddressType = optionEntity;
            personEntity.AddressId = person.AddressId;
            personEntity.Address.Id = person.AddressId;

            // Map the address entity
            AddressEntity addressEntity = _mapper.Map<AddressEntity>(personEntity.Address);
            addressEntity.Id = person.AddressId;

            using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            {
                try
                {
                    // Add address to address repository
                    await _addressRepository.Update(addressEntity);

                    // Add person to person repository
                    await _personRepository.Update(personEntity);

                    // Commit the transaction
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Failed to save data.", ex);
                }
            }

            return person;
        }

        public async Task<Person> PostAsync(Person person)
        {
            // Map Person object to PersonEntity object
            PersonEntity personEntity = _mapper.Map<PersonEntity>(person);
            // Map Address object to AddressEntity object
            AddressEntity addressEntity = _mapper.Map<AddressEntity>(personEntity.Address);
            // Get the Option for a residential address
            OptionEntity optionEntity = await _optionRepository.GetOptionAsync("Residential");
            addressEntity.AddressTypeId = optionEntity.Id;
            addressEntity.AddressType = optionEntity;

            using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            {
                try
                {
                    // Add address to address repository
                    await _addressRepository.Insert(addressEntity);
                    
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
