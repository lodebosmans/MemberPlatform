using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class PriceAgreement
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


        // Navigation properties
        public Contract Contract { get; set; }        
        public Option DiscountType { get; set; }       
        public Person Approver { get; set; }        
        public Option PriceAgreementStatus { get; set; }
        //public ICollection<Status> PriceAgreementStatus { get; set; }

    }
}
