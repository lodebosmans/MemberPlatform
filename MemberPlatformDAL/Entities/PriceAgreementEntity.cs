using System.ComponentModel.DataAnnotations.Schema;

namespace MemberPlatformDAL.Entities
{
    public class PriceAgreementEntity
    {
        // Attributes
        public int Id { get; set; }

        [ForeignKey("ContractId")]
        public int ContractId { get; set; }         //Foreign key relationship

        [ForeignKey("DiscountTypeId")]
        public int DiscountTypeId { get; set; }         //Foreign key relationship

        [ForeignKey("ApproverId")]
        public int ApproverId { get; set; }         //Foreign key relationship

        [ForeignKey("PriceAgreementStatusId")]
        public int PriceAgreementStatusId { get; set; }

        public int DiscountAmount { get; set; }
        public int PriceBillable { get; set; }
        public string StructuredMessage { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Comment { get; set; }

        // Navigation properties
        public ContractEntity Contract { get; set; }

        public OptionEntity DiscountType { get; set; }
        public PersonEntity Approver { get; set; }
        public OptionEntity PriceAgreementStatus { get; set; }
        //public ICollection<Status> PriceAgreementStatus { get; set; }
    }
}
