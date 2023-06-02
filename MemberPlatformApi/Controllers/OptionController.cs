using MemberPlatformCore.Models;
using MemberPlatformCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace MemberPlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        private readonly IOptionService _optionService;

        public OptionController(IOptionService optionService)
        {
            _optionService = optionService;
        }

        [HttpGet]
        public async Task<List<Option>> GetAllAsync()
        {
            return await _optionService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Option> GetByIdAsync(int id)
        {
            return await _optionService.GetByIdAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<Option> UpdateAsync(int id, Option option)
        {
            return await _optionService.UpdateAsync(id, option);
        }

        [HttpPost]
        public async Task<Option> PostAsync(Option option)
        {
            return await _optionService.PostAsync(option);
        }

        [HttpDelete("{id}")]
        public async Task<Option> DeleteAsync(int id)
        {
            return await _optionService.DeleteAsync(id);
        }

        [HttpGet("type")]
        public async Task<List<Option>> GetOptionsByTypeAsync(string type)
        {
            return await _optionService.GetAllByTypeAsync(type);
        }
    }
}
