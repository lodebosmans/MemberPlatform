using MemberPlatformCore.Models;
using MemberPlatformCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemberPlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractPersonInvolvementController : ControllerBase
    {

        private readonly IContractPersonInvolvementService _contractPersonInvolvementService;

        public ContractPersonInvolvementController(IContractPersonInvolvementService contractPersonInvolvementService)
        {
            _contractPersonInvolvementService = contractPersonInvolvementService;
        }

        [HttpGet]
        public async Task<List<ContractPersonInvolvement>> GetAllAsync()
        {
            return await _contractPersonInvolvementService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ContractPersonInvolvement> GetByIdAsync(int id)
        {
            return await _contractPersonInvolvementService.GetByIdAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<ContractPersonInvolvement> UpdateAsync(int id, ContractPersonInvolvement contractPersonInvolvement)
        {
            return await _contractPersonInvolvementService.UpdateAsync(id, contractPersonInvolvement);
        }

        [HttpPost]
        public async Task<ContractPersonInvolvement> PostAsync(ContractPersonInvolvement contractPersonInvolvement)
        {
            return await _contractPersonInvolvementService.PostAsync(contractPersonInvolvement);
        }

        [HttpDelete("{id}")]
        public async Task<ContractPersonInvolvement> DeleteAsync(int id)
        {
            return await _contractPersonInvolvementService.DeleteAsync(id);
        }
    }
}
