using MemberPlatformDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.UoW
{
    public interface IUnitOfWork
    {
        GenericRepository<AddressEntity> AddressRepository { get; }
        GenericRepository<Option> OptionRepository { get; }
        GenericRepository<OptionType> OptionTypeRepository { get; }
        GenericRepository<ProductDefinition> ProductDefinitionRepository { get; }
        GenericRepository<ProductUnit> ProductUnitRepository { get; }
        GenericRepository<ContractPersonInvolvement> ContractPersonInvolvementRepository { get;}
        GenericRepository<Contract> ContractRepository { get; }




        Task SaveAsync();
    }
}
