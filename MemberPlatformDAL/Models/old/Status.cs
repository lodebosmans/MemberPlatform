using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class Status
    {
        // Attributes
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation properties
        ICollection<CourseSessionStatus> CourseSessionStatuses { get; set; }
        ICollection<CourseStatus> CourseStatuses { get; set;}

    }
}
