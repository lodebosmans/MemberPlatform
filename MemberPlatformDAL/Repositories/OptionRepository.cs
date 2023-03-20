using MemberPlatformDAL.Data;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Repositories
{
    public class OptionRepository : GenericRepository<OptionEntity> , IOptionRepository
    {
        private DataContext _context;
        public OptionRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        public bool OptionExists(int id)
        {
            return _context.Options.Any(e => e.Id == id);
        }
    }
}
