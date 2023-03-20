using MemberPlatformCore.Models;
using MemberPlatformCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace MemberPlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionTypeController : ControllerBase
    {
        private readonly IOptionTypeService _optionTypeService;

        public OptionTypeController(IOptionTypeService optionTypeService)
        {
            _optionTypeService = optionTypeService;
        }

        [HttpGet]
        public async Task<List<OptionType>> GetAllAsync()
        {
            return await _optionTypeService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<OptionType> GetByIdAsync(int id)
        {
            return await _optionTypeService.GetByIdAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<OptionType> UpdateAsync(int id, OptionType optionType)
        {
            return await _optionTypeService.UpdateAsync(id, optionType);
        }
    }
}
