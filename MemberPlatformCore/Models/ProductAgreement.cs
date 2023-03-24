using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformCore.Models
{
    public class ProductAgreement
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public int ProductDefinitionId { get; set; }
    }
}
