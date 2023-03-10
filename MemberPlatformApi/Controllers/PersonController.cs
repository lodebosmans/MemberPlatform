using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MemberPlatformDAL.Data;
using MemberPlatformDAL.Models;
using MemberPlatformDAL.UoW;

namespace MemberPlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public PersonsController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Persons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            var persons = await _uow.PersonRepository.GetAllAsync();
            return persons.ToList();
        }

        // GET: api/Persons/5
        [HttpGet("{id}")]
        public PersonWithAddressDTO GetPersonWithAddress(int id)
        //public async Task<ActionResult<Person>> GetPerson(int id)
        {
            //var person = await _uow.PersonRepository.GetByIDAsync(id, includeProperties: "Address");

            //if (person == null)
            //{
            //    return NotFound();
            //}

            //return person;
            // Get the person with the specified id
            var person = _uow.PersonRepository.Get(p => p.Id == id).FirstOrDefault();
            if (person == null)
            {
                return null;
            }

            // Get the person's address
            var address = _uow.AddressRepository.Get(a => a.Id == person.AddressId).FirstOrDefault();
            if (address == null)
            {
                return null;
              
            }
            // Map the person and address to a DTO
            var dto = new PersonWithAddressDTO
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Gender = person.Gender,
                DateOfBirth = person.DateOfBirth,
                InsuranceCompany = person.InsuranceCompany,
                MobilePhone = person.MobilePhone,
                EmailAddress = person.EmailAddress,
                IdentityNumber = person.IdentityNumber,
                PrivacyApproval = person.PrivacyApproval,
                Address = new AddressDTO
                {
                    Id = address.Id,
                    Name = address.Name,
                    Street = address.Street,
                    Number = address.Number,
                    Box = address.Box,
                    PostalCode = address.PostalCode,
                    City = address.City,
                    Country = address.Country,
                    AddressType = address.AddressType?.Name
                }
            };

            return dto;
        }

        // PUT: api/Persons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {

            if (id != person.Id)
            {
                return BadRequest();
            }

            _uow.PersonRepository.Update(person);

            try
            {
                await _uow.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/Persons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            _uow.PersonRepository.Insert(person);
            await _uow.SaveAsync();

            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        // DELETE: api/Persons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _uow.PersonRepository.GetByIDAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _uow.PersonRepository.Delete(id);
            await _uow.SaveAsync();

            return NoContent();
        }

        private bool PersonExists(int id)
        {
            return _uow.PersonRepository.Get(e => e.Id == id).Any();
        }

        public class PersonWithAddressDTO
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Gender { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string InsuranceCompany { get; set; }
            public string MobilePhone { get; set; }
            public string EmailAddress { get; set; }
            public string IdentityNumber { get; set; }
            public bool PrivacyApproval { get; set; }
            public object Address { get; set; }
        }

        public class AddressDTO
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Street { get; set; }
            public string Number { get; set; }
            public string Box { get; set; }
            public string PostalCode { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string AddressType { get; set; }
        }
    }
}
