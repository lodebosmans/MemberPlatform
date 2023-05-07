using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public interface IOptionTypeRepository : IGenericRepository<OptionTypeEntity>
    {
        Task<OptionTypeEntity> GetOptionTypeAsync(string optionTypeName);
    }
}
