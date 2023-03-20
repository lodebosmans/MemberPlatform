using MemberPlatformCore.Models;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;

namespace MemberPlatformCore.Services
{
    public interface IOptionSevice 
    {
        Task<Option> GetByIDAsync(int id);
    }
}
