using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public interface IAddressRepository : IGenericRepository<AddressEntity>
    {
        bool AddressExists(int id);

        Task<AddressEntity> GetByIDAsync(int id);

        Task<List<AddressEntity>> GetAllAsync();
    }
}
