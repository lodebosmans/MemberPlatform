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
        public int Id { get; set; }

        [ForeignKey("AgreementId")]
        public int? AgreementId { get; set; }         //Foreign key relationship
        public Agreement Agreement { get; set; }        //Navigation property: 1 Agreemnet per AgreementDiscount

        [ForeignKey("DiscountId")]
        public int? DiscountId { get; set; }         //Foreign key relationship
        public Option Discount { get; set; }        //Navigation property: 1 Agreemnet per AgreementDiscount

        [ForeignKey("DiscountApproverId")]
        public int? DiscountApproverId { get; set; }         //Foreign key relationship
        public Person DiscountApprover { get; set; }        //Navigation property: 1 Agreemnet per AgreementDiscount

        public string DiscountAmount { get; set; } 



    }
}
