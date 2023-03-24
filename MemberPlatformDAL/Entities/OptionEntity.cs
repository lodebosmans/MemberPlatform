using System.ComponentModel.DataAnnotations.Schema;

namespace MemberPlatformDAL.Entities
{
    public class OptionEntity
    {
        // Attributes
        public int Id { get; set; }

        public string Name { get; set; }
        public int OptionTypeId { get; set; }        //Foreign key relationship

        // Navigation properties
        public OptionTypeEntity? OptionType { get; set; }   //Navigation property : 1 OptionType per Option

        [InverseProperty("Role")]
        public ICollection<ContractPersonInvolvementEntity>? ContractPersonInvolvementType { get; set; }

        [InverseProperty("ContractType")]
        public ICollection<ContractEntity>? ContractType { get; set; }

        [InverseProperty("Relation")]
        public ICollection<PersonPersonRelationEntity>? PersonPersonRelationType { get; set; }

        [InverseProperty("ProductUnitStatus")]
        public ICollection<ProductUnitEntity>? ProductUnitStatus { get; set; }

        [InverseProperty("TicketItemStatus")]
        public ICollection<TicketItemEntity>? TicketItemStatus { get; set; }

        [InverseProperty("DiscountType")]
        public ICollection<PriceAgreementEntity>? DiscountType { get; set; }

        [InverseProperty("PriceAgreementStatus")]
        public ICollection<PriceAgreementEntity>? PriceAgreementStatus { get; set; }

        [InverseProperty("SalesItemType")]
        public ICollection<SalesItemEntity>? SalesItemType { get; set; }

        [InverseProperty("ProductDefinitionStatus")]
        public ICollection<ProductDefinitionEntity>? ProductDefinitionStatus { get; set; }

        [InverseProperty("ProductDefinitionFormat")]
        public ICollection<ProductDefinitionEntity>? ProductDefinitionFormat { get; set; }

        [InverseProperty("ProductDefinitionSport")]
        public ICollection<ProductDefinitionEntity>? ProductDefinitionSport { get; set; }

        [InverseProperty("AddressType")]
        public ICollection<AddressEntity>? AddressType { get; set; }
    }
}
