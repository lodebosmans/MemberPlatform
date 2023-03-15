using MemberPlatformDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.UoW
{
    public interface IUnitOfWork
    {
        GenericRepository<Person> PersonRepository { get; }
        GenericRepository<Address> AddressRepository { get; }
        GenericRepository<Option> OptionRepository { get; }
        GenericRepository<OptionType> OptionTypeRepository { get; }



        Task SaveAsync();
    }
}
