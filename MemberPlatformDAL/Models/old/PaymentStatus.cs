using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class PaymentStatus
    {
        public  int Id { get; set; }
        public string Status { get; set; }


        //Navigation property
        //Paymentsstatus can be related to 0 or more InvoicePaymentStatuses (1 to many relationShip)
        public ICollection<InvoicePaymentStatus> InvoicePaymentStatuses { get; set; }
    }
}
