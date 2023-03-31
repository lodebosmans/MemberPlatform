using MemberPlatformCore.Models;

namespace MemberPlatformCore.Services
{
    public interface IProductDefinitionService
    {
        Task<ProductDefinition> DeleteAsync(int id);

        Task<List<ProductDefinition>> GetAllAsync();

        Task<ProductDefinition> GetByIdAsync(int id);

        Task<ProductDefinition> PostAsync(ProductDefinition productDefinition);

        Task<ProductDefinition> UpdateAsync(int id, ProductDefinition productDefinition);
    }
}
