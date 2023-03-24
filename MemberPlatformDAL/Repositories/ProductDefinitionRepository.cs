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
    public class ProductDefinitionRepository : GenericRepository<ProductDefinitionEntity>, IProductDefinitionRepository
    {

        private DataContext _context;

        public ProductDefinitionRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        public bool ProductDefinitionExists(int id)
        {
            return _context.ProductDefinitions.Any(a => a.Id == id);
        }
    }
}
