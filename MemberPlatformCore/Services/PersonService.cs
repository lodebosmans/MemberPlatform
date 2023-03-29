using AutoMapper;
using MemberPlatformCore.Models;
using MemberPlatformDAL.Data;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MemberPlatformCore.Services
{
    public class PersonService : IPersonService
    {
        private IPersonRepository _personRepository;
        private IAddressRepository _addressRepository;
        private IOptionRepository _optionRepository;
        private DataContext _context;
        private IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IAddressRepository addressRepository, IOptionRepository optionRepository, DataContext context, IMapper mapper)
        {
            _personRepository = personRepository;
            _addressRepository = addressRepository;
            _optionRepository = optionRepository;
            _context = context;
            _mapper = mapper;
        }

        public async Task<Person> GetPersonAsync(int id)
        {
            PersonEntity entity = await _personRepository.GetByIdAsync(id);
            // The following lines of code are necessary for the automapper to be able to map the persons address from the addresrepo and the addresType info from the optionrepo
            // to the person Model
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
                Person person = _mapper.Map<Person>(entity);
                people.Add(person);
            }

            return people;
        }
        public async Task UpdateAsync(int id, Person person)
        {

            //// Map the Person object to an PersonEntity object
            //PersonEntity entity = _mapper.Map<PersonEntity>(person);

            //// Call the UpdateAsync method of the repository to update the Person entity
            //await _personRepository.Update(entity);
            //await _addressRepository.Update(entity.Address);
            // Map Person object to PersonEntity object
            PersonEntity entity = _mapper.Map<PersonEntity>(person);

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // Update person in person repository
                    await _personRepository.Update(entity);

                    // Map Address object to AddressEntity object
                    AddressEntity addressEntity = _mapper.Map<AddressEntity>(entity.Address);

                    // Update address in address repository
                    await _addressRepository.Update(addressEntity);

                    // Commit the transaction
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    // If an exception is thrown, roll back the transaction
                    await transaction.RollbackAsync();
                    throw ex;
                }
            }
        }
        public async Task<Person> PostAsync(Person person)
        {
            // Map Person object to PersonEntity object
            PersonEntity entity = _mapper.Map<PersonEntity>(person);

            // Map Address object to AddressEntity object
            AddressEntity addressEntity = _mapper.Map<AddressEntity>(entity.Address);

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // Add address to address repository
                    await _addressRepository.Insert(addressEntity);

                    // Set address ID in person entity
                    entity.AddressId = addressEntity.Id;

                    // Add person to person repository
                    await _personRepository.Insert(entity);

                    // Commit the transaction
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    // If an exception is thrown, roll back the transaction
                    await transaction.RollbackAsync();
                    throw ex;
                }
            }

            // Map PersonEntity object back to Person object and return
            return _mapper.Map<Person>(entity);
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
