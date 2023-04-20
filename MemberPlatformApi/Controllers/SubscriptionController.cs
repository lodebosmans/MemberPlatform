using MemberPlatformCore.Models;
using MemberPlatformCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemberPlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly SubscriptionService _service;

        public SubscriptionController(SubscriptionService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> SaveDataAsync([FromBody] SubscriptionDTO myData)
        {
            try
            {
                await _service.SaveDataAsync(myData.Contract, myData.ContractPersonInvolvement, myData.PriceAgreement, myData.ProductAgreement);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
