using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class AgreementDiscount
    {
        // Attributes
        public int Id { get; set; }
        [ForeignKey("AgreementId")]
        public int AgreementId { get; set; }         //Foreign key relationship
        [ForeignKey("DiscountTypeId")]
        public int DiscountTypeId { get; set; }         //Foreign key relationship
        [ForeignKey("DiscountApproverId")]
        public int DiscountApproverId { get; set; }         //Foreign key relationship
        public int DiscountAmount { get; set; }

        // Navigation properties
        public Agreement Agreement { get; set; }        
        public Option DiscountType { get; set; }       
        public Person DiscountApprover { get; set; }        

    }
}
