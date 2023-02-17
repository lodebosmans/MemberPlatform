using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class CourseSession
    {
        // Attributes
        public int Id { get; set; }
        public int CourseId { get; set; }
        public DateTime Date { get; set; }
        public string? Comment { get; set; }
        public string Location { get; set; }
        public DateTime ScheduledStartTime { get; set; }
        public DateTime ScheduledEndTime { get; set; }
        public DateTime? ActualStartTime { get; set; }
        public DateTime? AcutalEndTime { get; set; }

        // Navigation properties
        ICollection<CourseSessionTrainer> CourseSessionTrainers { get; set; }
        public Course Course { get; set; }
        ICollection<CourseSessionStatus> courseSessionStatuses { get; set; }

    }
}
