using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformCore.Models
{
    public class PriceAgreement
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public int DiscountTypeId { get; set; }
        public int ApproverId { get; set; }
        public int PriceAgreementStatusId { get; set; }
        public int DiscountAmount { get; set; }
        public int PriceBillable { get; set; }
        public string StructuredMessage { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Comment { get; set; }
    }
}
