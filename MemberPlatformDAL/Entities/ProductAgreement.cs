using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Entities
{
    public class ProductAgreement
    {
        // Attributes
        public int Id { get; set; }
        [ForeignKey("ContractId")]
        public int ContractId { get; set; }         //Foreign key relationship
        public int ProductDefinitionId { get; set; }


        // Navigation properties
        public Contract Contract { get; set; }        //Navigation property: 1 Contract per Agreement
        public ProductDefinition ProductDefinition { get; set; }

    }
}
