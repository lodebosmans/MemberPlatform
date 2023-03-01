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
        public int Id { get; set; }
        public string Name { get; set; }

        public int OptionTypeId { get; set; }        //Foreign key relationship
        public OptionType OptionType { get; set; }   //Navigation property : 1 OptionType per Option

        [InverseProperty("Role")]
        public ICollection<ContractPersonRole> ContractPersonRolesRole { get; set; }

        [InverseProperty("Status")]
        public ICollection<AgreementStatus> AgreementStatusesStatus { get; set; }

        [InverseProperty("Type")]
        public ICollection<Contract> ContractsType { get; set; }

        [InverseProperty("Relation")]
        public ICollection<PersonRelationship> PersonRelationshipsRelation { get; set; }

        [InverseProperty("Sport")]
        public ICollection<AgreementSport> AgreementSportsSport { get; set;}

        [InverseProperty("Format")]
        public ICollection<AgreementFormat> AgreementFormatsFormat { get; set; }

        [InverseProperty("ProductStatus")]
        public ICollection<Product> ProductsProductStatus { get; set; }

        [InverseProperty("UnitStatus")]
        public ICollection<ProductUnit> ProductUnitsUnitStatus { get; set; }

        [InverseProperty("TicketStatus")]
        public ICollection<TicketItem> TicketItemsTicketStatus { get; set; }

        [InverseProperty("Discount")]
        public ICollection<AgreementDiscount> AgreementDiscountsDiscount { get; set; }

    }
}
