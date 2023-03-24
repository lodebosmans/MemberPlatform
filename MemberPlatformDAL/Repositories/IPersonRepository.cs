using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public interface IPersonRepository : IGenericRepository<PersonEntity>
    {
        Task<IEnumerable<PersonEntity>> GetAllWithAddressAsync();

        bool PersonExists(int id);
        Task<PersonEntity> UpdateAsync(PersonEntity entity);
        Task DeleteAsync(PersonEntity entity);
    }
}
