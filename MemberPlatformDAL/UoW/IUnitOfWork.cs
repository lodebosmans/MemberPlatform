using MemberPlatformDAL.Entities;

namespace MemberPlatformDAL.UoW
{
    public interface IUnitOfWork
    {
        GenericRepository<AddressEntity> AddressRepository { get; }
        GenericRepository<OptionEntity> OptionRepository { get; }
        GenericRepository<OptionTypeEntity> OptionTypeRepository { get; }
        GenericRepository<ProductDefinitionEntity> ProductDefinitionRepository { get; }
        GenericRepository<ProductUnitEntity> ProductUnitRepository { get; }
        GenericRepository<ContractPersonInvolvementEntity> ContractPersonInvolvementRepository { get; }
        GenericRepository<ContractEntity> ContractRepository { get; }

        Task SaveAsync();
    }
}
