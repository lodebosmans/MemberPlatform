using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public interface IProductDefinitionRepository : IGenericRepository<ProductDefinitionEntity>
    {
        Task<List<ProductDefinitionEntity>> GetAllByIdAsync(int id);
    }
}
