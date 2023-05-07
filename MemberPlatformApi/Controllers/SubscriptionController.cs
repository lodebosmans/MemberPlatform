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
        private readonly ISubscriptionService _service;

        public SubscriptionController(ISubscriptionService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> SaveDataAsync([FromBody] SubscriptionDTO myData)
        {
            try
            {
                await _service.SaveDataAsync(myData.productId, myData.personId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
        [HttpGet("{personId}/{year}")]

        public async Task<List<Subscription>> GetAllById(int personId, int year)
        {
            return await _service.GetAllById(personId, year);
            
        }
        [HttpGet("all")]

        public async Task<List<Subscription>> GetSubscriptionsAsync()
        {
            return await _service.GetSubscriptionsAsync();
        }





        //public async Task<IActionResult> SaveDataAsync([FromBody] SubscriptionDTO myData)
        //{
        //    try
        //    {
        //        await _service.SaveDataAsync(myData.Contract, myData.ContractPersonInvolvement, myData.PriceAgreement, myData.ProductAgreement);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { error = ex.Message });
        //    }
        //}
    }
}
