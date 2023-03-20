using System.ComponentModel.DataAnnotations.Schema;

namespace MemberPlatformDAL.Entities
{
    public class ProductAgreementEntity
    {
        // Attributes
        public int Id { get; set; }

        [ForeignKey("ContractId")]
        public int ContractId { get; set; }         //Foreign key relationship

        public int ProductDefinitionId { get; set; }

        // Navigation properties
        public ContractEntity Contract { get; set; }        //Navigation property: 1 Contract per Agreement

        public ProductDefinitionEntity ProductDefinition { get; set; }
    }
}
