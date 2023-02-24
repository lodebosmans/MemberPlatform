using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class CourseSessionStatus
    {
        public int Id { get; set;}

        //Foreign key relationship
        public int StatusId { get; set;}
        // Navigation Property : 1 status per CourseSessionStatus
        public Status Status { get; set; }

        //Foreign key realtionship
        public int CourseSessionId { get; set; }
        //Navigation property : 1 CourseSession per CoursesessionStatus
        public CourseSession CourseSession { get; set; }
    }
}
