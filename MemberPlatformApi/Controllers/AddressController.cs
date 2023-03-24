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
        public async Task<Address> GetByIdAsync(int id)
        {
            return await _addressService.GetByIdAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<Address> UpdateAsync(int id, Address address)
        {
            return await _addressService.UpdateAsync(id, address);
        }

        [HttpPost]
        public async Task<Address> PostAsync(Address address)
        {
            return await _addressService.PostAsync(address);
        }

        [HttpDelete("{id}")]
        public async Task<Address> DeleteAsync(int id)
        {
            return await _addressService.DeleteAsync(id);
        }

    }
}
