using MemberPlatformCore.Models;
using MemberPlatformCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace MemberPlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
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

        [HttpGet("withaddress")]
        public async Task<List<Person>> GetAllWithAddress()
        {
            return await _personService.GetAllWithAddressAsync();
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


        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _personService.DeleteAsync(id);
        }

    }
}
