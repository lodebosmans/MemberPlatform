using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class EnrollmentStatus
    {
        // Attributes
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation properties
        ICollection<PersonCourseEnrollmentStatus> PersonCourseEnrollmentStatuses { get; set; }
    }
}
