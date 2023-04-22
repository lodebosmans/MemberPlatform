using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public interface IPersonRepository : IGenericRepository<PersonEntity>
    {
        Task<IEnumerable<PersonEntity>> GetAllWithAddressAsync();
        Task<PersonEntity> GetByEmailAddressAsync(string emailAddress);

    }
}
