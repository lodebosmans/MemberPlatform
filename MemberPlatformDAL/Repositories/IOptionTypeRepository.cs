using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public interface IOptionTypeRepository : IGenericRepository<OptionTypeEntity>
    {
        bool OptionTypeExists(int id);
    }
}
