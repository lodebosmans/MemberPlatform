using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class CourseSessionTrainer
    {
        // Attributes
        public int Id { get; set; }
        public int CourseSessionId { get; set; }
        public int TrainerId { get; set; }

        // Navigation properties
        public Person Trainer { get; set; }
        public CourseSession CourseSession { get; set; }

    }
}
