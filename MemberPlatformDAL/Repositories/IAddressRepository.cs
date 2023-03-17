using MemberPlatformDAL.Entities;

namespace MemberPlatformDAL.Repositories
{
    public interface IAddressRepository
    {
        bool AddressExists(int id);
        Task<AddressEntity> GetByIDAsync(int id);
    }
}