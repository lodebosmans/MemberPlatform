using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformCore.Models
{
    public class ContractPersonInvolvement
    {
        public int Id { get; set; }
        public int PersonId { get; set; }          //Foreign key relationship
        public int ContractId { get; set; }
        public int RoleId { get; set; }
    }
}
