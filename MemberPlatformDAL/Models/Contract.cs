using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class Contract
    {
        // Attributes
        public int Id { get; set; }
        public DateTime ContractDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ForeignKey("ContractTypeId")]
        public int ContractTypeId { get; set; }        //Foreign key relationship

        // Navigations properties
        public Option ContractType { get; set; }        //Navigation property: 1 type per Contract
        public ICollection<ContractPersonRole> ContractPersonRoles { get; set; } //Contract can be related to 0 or more ContractPersonRole (1 to many relationShip)
        public ICollection<Agreement> Agreements { get; set; }
    }
}
