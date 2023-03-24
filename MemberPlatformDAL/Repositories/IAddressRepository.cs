using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public interface IAddressRepository : IGenericRepository<AddressEntity>
    {
        bool AddressExists(int id);

        Task<AddressEntity> GetByIdAsync(int id);

        Task<List<AddressEntity>> GetAllAsync();

        Task<AddressEntity> UpdateAsync(AddressEntity entity);
        Task SaveAsync();
        Task DeleteAsync(AddressEntity entity);
        Task<AddressEntity> AddAsync(AddressEntity entity);
    }
}
