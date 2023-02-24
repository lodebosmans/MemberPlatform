using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class TrainerCourse
    {
        // Attributes
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public int CourseId { get; set; }

        // Navigation properties
        public Person Trainer { get; set; }
        public Course Course { get; set; }

    }
}
