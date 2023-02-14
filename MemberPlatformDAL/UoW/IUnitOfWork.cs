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
        GenericRepository<RelationShip> RelationShipRepository { get; }
        GenericRepository<CourseType> CourseTypeRepository { get; }

        Task SaveAsync();
    }
}
