using AutoMapper;
using MemberPlatformCore.Models;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.Repositories;

namespace MemberPlatformCore.Services
{
    public class PersonService : IPersonService
    {
        private IPersonRepository _personRepository;
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

        public async Task<Person> GetPersonByEmailAddressAsync(string emailAddress)
        {
            PersonEntity entity = await _personRepository.GetByEmailAddressAsync(emailAddress);
            Person person = _mapper.Map<Person>(entity);

            return person;
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
            //    // Map Person object to PersonEntity object
            //    PersonEntity entity = _mapper.Map<PersonEntity>(person);

            //    // Map Address object to AddressEntity object
            //    AddressEntity addressEntity = _mapper.Map<AddressEntity>(entity.Address);

            //    using (var transaction = _context.Database.BeginTransaction())
            //    {
            //        try
            //        {
            //            // Add address to address repository
            //            await _addressRepository.Insert(addressEntity);

            //            // Set address ID in person entity
            //            entity.AddressId = addressEntity.Id;

            //            // Add person to person repository
            //            await _personRepository.Insert(entity);

            //            // Commit the transaction
            //            await transaction.CommitAsync();
            //        }
            //        catch (Exception ex)
            //        {
            //            // If an exception is thrown, roll back the transaction
            //            await transaction.RollbackAsync();
            //            throw ex;
            //        }
            //    }

            //    // Map PersonEntity object back to Person object and return
            //    return _mapper.Map<Person>(entity);

            throw new NotImplementedException();    
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
