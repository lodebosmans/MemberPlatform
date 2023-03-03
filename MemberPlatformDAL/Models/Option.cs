using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class Option
    {
        // Attributes
        public int Id { get; set; }
        public string Name { get; set; }
        public int OptionTypeId { get; set; }        //Foreign key relationship

        // Navigation properties
        public OptionType OptionType { get; set; }   //Navigation property : 1 OptionType per Option

        [InverseProperty("Role")]
        public ICollection<ContractPersonRole> ContractPersonRoleType { get; set; }

        [InverseProperty("Status")]
        public ICollection<AgreementStatus> AgreementStatusType { get; set; }

        [InverseProperty("ContractType")]
        public ICollection<Contract> ContractType { get; set; }

        [InverseProperty("Relation")]
        public ICollection<PersonRelationship> PersonRelationshipType { get; set; }

        [InverseProperty("Sport")]
        public ICollection<AgreementSport> AgreementSportType { get; set;}

        [InverseProperty("Format")]
        public ICollection<AgreementFormat> AgreementFormatType { get; set; }

        [InverseProperty("ProductStatus")]
        public ICollection<Product> ProductsStatus { get; set; }

        [InverseProperty("ProductUnitStatus")]
        public ICollection<ProductUnit> ProductUnitStatus { get; set; }

        [InverseProperty("TicketStatus")]
        public ICollection<TicketItem> TicketItemStatus { get; set; }

        [InverseProperty("DiscountType")]
        public ICollection<AgreementDiscount> AgreementDiscountType { get; set; }
        [InverseProperty("SalesItemType")]
        public ICollection<SalesItem> SalesItemType { get; set; }

    }
}
