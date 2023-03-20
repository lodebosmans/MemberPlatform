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
    }
}
