using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public interface IAddressRepository : IGenericRepository<AddressEntity>
    {
        bool AddressExists(int id);

        Task<AddressEntity> GetAddressWithAddressType(int id);

        Task<List<AddressEntity>> GetAllWithAddressTypeAsync();
    }
}
