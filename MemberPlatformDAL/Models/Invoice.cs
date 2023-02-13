using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string StructeredMessage { get; set; }

        public int? Discount { get; set; }

        //Foreign key relationship
        public int? DiscountTypeId { get; set; }
        //Nacvigation property : 1 DiscountType per Invoice
        public DiscountType? DiscountType { get; set; }


        //Navigation property
        //Invoice can be related to 0 or more InvoicePaymentStatuses (1 to many relationShip)
        public ICollection<InvoicePaymentStatus> InvoicePaymentStatuses { get; set; }

        //Navigation property
        //Invoice can be related to 0 or more PersonCourse (1 to many relationShip)
        public ICollection<PersonCourse> PersonCourses { get; set; }


    }
}
