using Microsoft.AspNetCore.Mvc;

namespace MemberPlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvolvementRoleController : ControllerBase
    {
        //private readonly IInvolvementRoleService _service;

        //public InvolvementRoleController(IInvolvementRoleService service)
        //{
        //    _service = service;
        //}

        //[HttpPost]
        //public async Task<IActionResult> SaveDataAsync([FromBody] SubscriptionDTO myData)
        //{
        //    try
        //    {
        //        await _service.SaveDataAsync(myData.productId, myData.personId);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { error = ex.Message });
        //    }
        //}
        //[HttpGet("{personId}/{year}")]

        //public async Task<List<Subscription>> GetAllById(int personId, int year)
        //{
        //    return await _service.GetAllById(personId, year);

        //}
    }
}
