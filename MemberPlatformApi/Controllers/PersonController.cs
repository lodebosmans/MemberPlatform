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
        public async Task<Person> UpdateAsync(int id, Person person)
        {
            return await _personService.UpdateAsync(id, person);
        }
        //// PUT: api/Persons/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPerson(int id, PersonEntity person)
        //{
        //    if (id != person.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _uow.PersonRepository.Update(person);

        //    try
        //    {
        //        await _uow.SaveAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PersonExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    return NoContent();
        //}

        //// POST: api/Persons
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<PersonEntity>> PostPerson(PersonEntity person)
        //{
        //    _uow.PersonRepository.Insert(person);
        //    await _uow.SaveAsync();

        //    //return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        //    return CreatedAtAction(nameof(GetPersonWithAddressAsync), new { id = person.Id }, person);

        //}

        //// DELETE: api/Persons/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePerson(int id)
        //{
        //    var person = await _uow.PersonRepository.GetByIDAsync(id);
        //    if (person == null)
        //    {
        //        return NotFound();
        //    }

        //    _uow.PersonRepository.Delete(id);
        //    await _uow.SaveAsync();

        //    return NoContent();
        //}
    }
}
