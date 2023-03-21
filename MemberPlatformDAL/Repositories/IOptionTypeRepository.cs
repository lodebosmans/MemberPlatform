using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public interface IOptionTypeRepository : IGenericRepository<OptionTypeEntity>
    {
        bool OptionTypeExists(int id);

        Task<List<OptionTypeEntity>> GetAllAsync();

        Task<OptionTypeEntity> UpdateAsync(OptionTypeEntity entity);

        Task<OptionTypeEntity> AddAsync(OptionTypeEntity entity);

        Task DeleteAsync(OptionTypeEntity entity);

        Task<OptionTypeEntity> GetByNameAsync(string name);
    }
}
