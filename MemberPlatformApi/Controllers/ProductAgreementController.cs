using MemberPlatformCore.Models;
using MemberPlatformCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace MemberPlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAgreementController : ControllerBase
    {
        private readonly IProductAgreementService _productAgreementService;

        public ProductAgreementController(IProductAgreementService productAgreementService)
        {
            _productAgreementService = productAgreementService;
        }

        [HttpGet]
        public async Task<List<ProductAgreement>> GetAllAsync()
        {
            return await _productAgreementService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ProductAgreement> GetByIdAsync(int id)
        {
            return await _productAgreementService.GetByIdAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<ProductAgreement> UpdateAsync(int id, ProductAgreement productAgreement)
        {
            return await _productAgreementService.UpdateAsync(id, productAgreement);
        }

        [HttpPost]
        public async Task<ProductAgreement> PostAsync(ProductAgreement productAgreement)
        {
            return await _productAgreementService.PostAsync(productAgreement);
        }

        [HttpDelete("{id}")]
        public async Task<ProductAgreement> DeleteAsync(int id)
        {
            return await _productAgreementService.DeleteAsync(id);
        }
    }
}
