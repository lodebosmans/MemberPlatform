using MemberPlatformCore.Models;
using MemberPlatformCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace MemberPlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesItemController : ControllerBase
    {
        private readonly ISalesItemService _salesItemService;

        public SalesItemController(ISalesItemService salesItemService)
        {
            _salesItemService = salesItemService;
        }

        [HttpGet]
        public async Task<List<SalesItem>> GetAllAsync()
        {
            return await _salesItemService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<SalesItem> GetByIdAsync(int id)
        {
            return await _salesItemService.GetByIdAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<SalesItem> UpdateAsync(int id, SalesItem salesItem)
        {
            return await _salesItemService.UpdateAsync(id, salesItem);
        }

        [HttpPost]
        public async Task<SalesItem> PostAsync(SalesItem salesItem)
        {
            return await _salesItemService.PostAsync(salesItem);
        }

        [HttpDelete("{id}")]
        public async Task<SalesItem> DeleteAsync(int id)
        {
            return await _salesItemService.DeleteAsync(id);
        }
    }
}
