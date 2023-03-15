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
        public int? OptionTypeId { get; set; }        //Foreign key relationship

        // Navigation properties
        public OptionType? OptionType { get; set; }   //Navigation property : 1 OptionType per Option

        [InverseProperty("Role")]
        public ICollection<ContractPersonInvolvement>? ContractPersonInvolvementType { get; set; }

        //[InverseProperty("StatusType")]
        //public ICollection<Status> StatusType { get; set; }

        [InverseProperty("ContractType")]
        public ICollection<Contract>? ContractType { get; set; }
        [InverseProperty("Relation")]
        public ICollection<PersonPersonRelation>? PersonPersonRelationType { get; set; }
        [InverseProperty("ProductUnitStatus")]
        public ICollection<ProductUnit>? ProductUnitStatus { get; set; }

        [InverseProperty("TicketItemStatus")]
        public ICollection<TicketItem>? TicketItemStatus { get; set; }

        [InverseProperty("DiscountType")]
        public ICollection<PriceAgreement>? DiscountType { get; set; }
        [InverseProperty("PriceAgreementStatus")]
        public ICollection<PriceAgreement>? PriceAgreementStatus { get; set; }
        [InverseProperty("SalesItemType")]
        public ICollection<SalesItem>? SalesItemType { get; set; }
        [InverseProperty("ProductDefinitionStatus")]
        public ICollection<ProductDefinition>? ProductDefinitionStatus { get; set; }
        [InverseProperty("ProductDefinitionFormat")]
        public ICollection<ProductDefinition>? ProductDefinitionFormat { get; set; }
        [InverseProperty("ProductDefinitionSport")]
        public ICollection<ProductDefinition>? ProductDefinitionSport { get; set; }
    }
}
