using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class PersonCourse
    {
        // Attributes
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int CourseId { get; set; }
        public int? InvoiceId { get; set; }
        public int? DiscountTypeId { get; set; }
        public float? Discount { get; set; }
        public int SubmitterId { get; set; }

        // Naviagation properties
        public Person Member { get; set; }
        public Course Course { get; set; }
        public Invoice Invoice { get; set; }
        public DiscountType DiscountType { get; set; }
        public Person Submitter { get; set; }
        public ICollection<PersonCourseEnrollmentStatus> personCourseEnrollmentStatuses { get; set; }


    }
}
