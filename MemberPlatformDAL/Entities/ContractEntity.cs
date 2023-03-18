using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Entities
{
    public class ContractEntity
    {
        // Attributes
        public int Id { get; set; }
        public DateTime ContractDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ForeignKey("ContractTypeId")]
        public int ContractTypeId { get; set; }        //Foreign key relationship

        // Navigations properties
        public OptionEntity ContractType { get; set; }        //Navigation property: 1 type per Contract
        public ICollection<ContractPersonInvolvementEntity> ContractPersonInvolvements { get; set; } //Contract can be related to 0 or more ContractPersonRole (1 to many relationShip)
        public ICollection<ProductAgreementEntity> ProductAgreements { get; set; }
    }
}