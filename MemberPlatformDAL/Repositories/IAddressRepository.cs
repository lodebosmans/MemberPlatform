using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Repositories
{
    public interface IAddressRepository : IGenericRepository<AddressEntity>
    {
        Task<AddressEntity> GetAddressWithAddressType(int id);

        Task<List<AddressEntity>> GetAllWithAddressTypeAsync();

        Task<List<AddressEntity>> GetTrainingFacilities();
    }
}
