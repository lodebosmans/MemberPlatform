using MemberPlatformCore.Models;
using MemberPlatformCore.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MemberPlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDefinitionController : ControllerBase
    {
        private readonly IProductDefinitionService _productDefinitionService;

        public ProductDefinitionController(IProductDefinitionService productDefinitionService)
        {
            _productDefinitionService = productDefinitionService;
        }

        [HttpGet]
        public async Task<List<ProductDefinition>> GetAllAsync()
        {
            return await _productDefinitionService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ProductDefinition> GetByIdAsync(int id)
        {
            return await _productDefinitionService.GetByIdAsync(id);
        }

        [HttpGet("AllById/{id}/{year}")]
        public async Task<List<ProductDefinition>> GetAllByIdAsync(int id, int year)
        {
            return await _productDefinitionService.GetAllByIdAsync(id, year);
        }

        [HttpPut("{id}")]
        public async Task<ProductDefinition> UpdateAsync(int id, ProductDefinition productDefinition)
        {
            return await _productDefinitionService.UpdateAsync(id, productDefinition);
        }

        [HttpPost]
        public async Task<ProductDefinition> PostAsync(ProductDefinition productDefinition)
        {
            return await _productDefinitionService.PostAsync(productDefinition);
        }

        [HttpDelete("{id}")]
        public async Task<ProductDefinition> DeleteAsync(int id)
        {
            return await _productDefinitionService.DeleteAsync(id);
        }
    }
}
