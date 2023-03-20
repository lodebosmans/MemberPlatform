using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public interface IOptionRepository : IGenericRepository<OptionEntity>
    {
        Task<OptionEntity> GetByIDAsync(int id);
        bool OptionExists(int id);
      
    }
}
