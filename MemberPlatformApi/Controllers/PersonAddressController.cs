using MemberPlatformCore.Models;
using MemberPlatformCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace MemberPlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonAddressController : ControllerBase
    {
        private readonly IPersonAddressService _personAddressService;

        public PersonAddressController(IPersonAddressService service)
        {
            _personAddressService = service;
        }

        [HttpPost]
        public async Task<IActionResult> SaveDataAsync([FromBody] PersonAddressDTO myData)
        {
            try
            {
                await _personAddressService.SaveDataAsync(myData.Person, myData.Address);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
