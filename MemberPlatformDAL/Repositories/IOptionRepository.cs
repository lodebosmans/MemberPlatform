using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public interface IOptionRepository : IGenericRepository<OptionEntity>
    {
        Task<OptionEntity> GetByIdAsync(int id);

        bool OptionExists(int id);

        Task<List<OptionEntity>> GetAllAsync();

        Task DeleteAsync(OptionEntity entity);

        Task<OptionEntity> UpdateAsync(OptionEntity entity);
        Task<OptionEntity> GetByNameAsync(string addressType);
        Task<OptionEntity> AddAsync(OptionEntity entity);
    }
}
