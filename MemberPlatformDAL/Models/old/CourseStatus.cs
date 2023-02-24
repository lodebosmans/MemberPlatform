using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class CourseStatus
    {
        // Attributes
        public int Id { get; set;}
        public int CourseId { get; set;}
        public int StatusId { get; set;}
        public int ApproverId { get; set;}

        // Navigation properties
        public Course Course { get; set;}
        public Status Status { get; set;}
        public Person Approver { get; set;}
    }
}
