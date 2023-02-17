using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class PersonCourseEnrollmentStatus
    {
        // Attributes
        public int Id { get; set; }
        public int MemberCourseId { get; set; }
        public int EnrollmentStatusId { get; set; }
        public string Comment { get; set; }
        public int ApproverId { get; set; }

        // Navigation properties
        public PersonCourse PersonCourse { get; set; }
        public EnrollmentStatus EnrollmentStatus { get; set; }
        public Person Approver { get; set; }

    }
}