using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class InvoicePaymentStatus
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime PaymentDate { get; set; }

        //Foreign key relationship
        public int InvoiceId { get; set; }
        //Navigation property : 1 Invoice Per InvoicePaymentStatus
        public Invoice Invoice { get; set; }

        //Foreign key relationship
        public int PaymentStatusId { get; set; }
        //Navigation property : 1 PaymentStatus per InvoicePaymentSatus
        public PaymentStatus PaymentStatus { get; set; }


    }
}
