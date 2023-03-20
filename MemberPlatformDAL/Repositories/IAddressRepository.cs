using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public interface IAddressRepository : IGenericRepository<AddressEntity>
    {
        bool AddressExists(int id);

        Task<AddressEntity> GetByIdAsync(int id);

        Task<List<AddressEntity>> GetAllAsync();
    }
}
