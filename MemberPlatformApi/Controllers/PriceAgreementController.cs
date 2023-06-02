using MemberPlatformCore.Models;
using MemberPlatformCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace MemberPlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceAgreementController : ControllerBase
    {
        private readonly IPriceAgreementService _priceAgreementService;

        public PriceAgreementController(IPriceAgreementService priceAgreementService)
        {
            _priceAgreementService = priceAgreementService;
        }

        [HttpGet]
        public async Task<List<PriceAgreement>> GetAllAsync()
        {
            return await _priceAgreementService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<PriceAgreement> GetByIdAsync(int id)
        {
            return await _priceAgreementService.GetByIdAsync(id);
        }

        [HttpGet("ByContractIdAndPersonId/{contractId}/{personId}/{year}")]
        public async Task<List<PriceAgreement>> GetByProductPersonYear(int contractId, int personId, int year)
        {
            return await _priceAgreementService.GetByProductPersonYear(contractId, personId, year);
        }

        [HttpPut("{id}")]
        public async Task<PriceAgreement> UpdateAsync(int id, PriceAgreement priceAgreement)
        {
            return await _priceAgreementService.UpdateAsync(id, priceAgreement);
        }

        [HttpPost]
        public async Task<PriceAgreement> PostAsync(PriceAgreement priceAgreement)
        {
            return await _priceAgreementService.PostAsync(priceAgreement);
        }

        [HttpDelete("{id}")]
        public async Task<PriceAgreement> DeleteAsync(int id)
        {
            return await _priceAgreementService.DeleteAsync(id);
        }
    }
}
