using MemberPlatformCore.Models;
using MemberPlatformCore.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MemberPlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<List<Address>> GetAllAsync()
        {
            return await _addressService.GetAllAsync();
        }

        //    // GET api/Address/5
        [HttpGet("{id}")]

        public async Task<Address> GetByIdAsync(int id )
        {
            return await _addressService.GetByIDAsync(id);
        }
        //    public async Task<ActionResult<AddressEntity>> GetAddress(int id)
        //    {
        //        var address = await _uow.AddressRepository.GetByIDAsync(id);

        //        if (address == null)
        //        {
        //            return NotFound();
        //        }

        //        return address;
        //    }

        //    // POST api/<AddressController>
        //    [HttpPost]
        //    public async Task<ActionResult<AddressEntity>> PostAddress(AddressEntity address)
        //    {
        //        _uow.AddressRepository.Insert(address);
        //        await _uow.SaveAsync();

        //        return CreatedAtAction("GetAddress", new { id = address.Id }, address);
        //    }

        //    // PUT api/Address/5
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutAddress(int id, AddressEntity address)
        //    {
        //        if (id != address.Id)
        //        {
        //            return BadRequest();
        //        }

        //        _uow.AddressRepository.Update(address);

        //        try
        //        {
        //            await _uow.SaveAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!AddressExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return NoContent();
        //    }

        //    private bool AddressExists(int id)
        //    {
        //        return _uow.AddressRepository.Get(e => e.Id == id).Any();
        //    }

        //    // DELETE api/Address/5
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeletePerson(int id)
        //    {
        //        var address = await _uow.AddressRepository.GetByIDAsync(id);
        //        if (address == null)
        //        {
        //            return NotFound();
        //        }

        //        _uow.AddressRepository.Delete(id);
        //        await _uow.SaveAsync();

        //        return NoContent();
        //    }
    }
}
