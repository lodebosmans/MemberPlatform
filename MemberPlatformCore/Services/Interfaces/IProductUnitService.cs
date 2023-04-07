using MemberPlatformCore.Models;

namespace MemberPlatformCore.Services
{
    public interface IProductUnitService
    {
        Task<ProductUnit> DeleteAsync(int id);

        Task<List<ProductUnit>> GetAllAsync();

        Task<ProductUnit> GetByIdAsync(int id);

        Task<ProductUnit> PostAsync(ProductUnit productUnit);

        Task<ProductUnit> UpdateAsync(int id, ProductUnit productUnit);
    }
}
