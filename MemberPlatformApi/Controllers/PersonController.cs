using MemberPlatformCore.Models;
using MemberPlatformCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MemberPlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        //// GET: api/Persons
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<PersonEntity>>> GetPersons()
        //{
        //    var persons = await _uow.PersonRepository.GetAllAsync();
        //    return persons.ToList();
        //}
        [HttpGet("personsIds/{emailAddress}")]
        public async Task<List<int>> GetPersonIdsAsync(string emailAddress)
        {
            return await _personService.GetPersonIdsAsync(emailAddress);
        }

        [HttpGet("withaddress")]
        public async Task<List<Person>> GetAllWithAddress()
        {
            return await _personService.GetAllWithAddressAsync();
        }

        [HttpGet("byemailaddress/{emailAddress}")]
        public async Task<List<Person>> GetByEmailAddress(string emailAddress)
        {
            return await _personService.GetPersonByEmailAddressAsync(emailAddress);
        }

        // GET: api/Persons/5
        [HttpGet("{id}")]
        public async Task<Person> GetPersonWithAddressAsync(int id)
        {
            return await _personService.GetPersonAsync(id);
        }

        [HttpPut("{id}")]
        public async Task UpdateAsync(int id, Person person)
        {
            await _personService.UpdateAsync(id, person);
        }

        [HttpPost]
        public async Task<Person> PostAsync(Person person)
        {
            return await _personService.PostAsync(person);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _personService.DeleteAsync(id);
        }
    }
}
