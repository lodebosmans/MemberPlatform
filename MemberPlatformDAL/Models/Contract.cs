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
        public int Id { get; set; }
        public DateTime ContractDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ForeignKey("TypeId")]
        public int TypeId { get; set; }        //Foreign key relationship
        public Option Type { get; set; }        //Navigation property: 1 type per Contract

        //Navigation property
        //Contract can be related to 0 or more ContractPersonRole (1 to many relationShip)
        public ICollection<ContractPersonRole> contractPersonRoles { get; set; }
        public ICollection<Agreement> agreements { get; set; }
    }
}
