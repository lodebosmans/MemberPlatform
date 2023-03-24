using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public interface IProductDefinitionRepository : IGenericRepository<ProductDefinitionEntity>
    {
        bool ProductDefinitionExists(int id);
    }
}
