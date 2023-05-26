using MemberPlatformCore.Models;
using MemberPlatformCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace MemberPlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContractService _contractService;

        public ContractController(IContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpGet]
        public async Task<List<Contract>> GetAllAsync()
        {
            return await _contractService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Contract> GetByIdAsync(int id)
        {
            return await _contractService.GetByIdAsync(id);
        }

        [HttpGet("contractExists/{productId}/{personId}")]
        public async Task<bool> ContractExists(int productId, int personId)
        {
            return await _contractService.ContractExists(productId, personId);
        }

        [HttpGet("adminRightsExists/{personId}")]
        public async Task<bool> adminExists(int personId)
        {
            return await _contractService.AdminRightsExists(personId);
        }

        [HttpPut("{id}")]
        public async Task<Contract> UpdateAsync(int id, Contract contract)
        {
            return await _contractService.UpdateAsync(id, contract);
        }

        [HttpPost]
        public async Task<Contract> PostAsync(Contract contract)
        {
            return await _contractService.PostAsync(contract);
        }

        [HttpDelete("{id}")]
        public async Task<Contract> DeleteAsync(int id)
        {
            return await _contractService.DeleteAsync(id);
        }
    }
}
