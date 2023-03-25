using MemberPlatformCore.Models;
using MemberPlatformCore.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MemberPlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductUnitController : ControllerBase
    {
        private readonly IProductUnitService _productUnitService;

        public ProductUnitController(IProductUnitService productUnitService)
        {
            _productUnitService = productUnitService;
        }

        [HttpGet]
        public async Task<List<ProductUnit>> GetAllAsync()
        {
            return await _productUnitService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ProductUnit> GetByIdAsync(int id)
        {
            return await _productUnitService.GetByIdAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<ProductUnit> UpdateAsync(int id, ProductUnit productUnit)
        {
            return await _productUnitService.UpdateAsync(id, productUnit);
        }

        [HttpPost]
        public async Task<ProductUnit> PostAsync(ProductUnit productUnit)
        {
            return await _productUnitService.PostAsync(productUnit);
        }

        [HttpDelete("{id}")]
        public async Task<ProductUnit> DeleteAsync(int id)
        {
            return await _productUnitService.DeleteAsync(id);
        }
    }
}
