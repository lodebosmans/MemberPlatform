using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class Course
    {
        // Attributes
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfSessions { get; set; }
        public int MaximumAmountOfParticipants { get; set; }
        public int Price { get; set; }
        public DateTime SubscriptionOpening { get; set; }
        public DateTime SubscriptionClosing { get; set; }
        public string? DayOfWeek { get; set; }
        public int? NumberOfGroups { get; set; }
        public int CourseTypeId { get; set; }
        public int StatusId { get; set; }

        // Navigation properties
        public ICollection<TrainerCourse> TrainerCourses { get; set; }
        public ICollection<PersonCourse> PersonCourses { get; set;}
        public ICollection<CourseSession> CourseSessions { get; set;}
        public ICollection<CourseStatus> CourseStatuses { get; set;}
        public ICollection<SubCourse> SubCourses { get; set;}
        public ICollection<CourseOffer> CourseOffers { get; set; }
        public CourseType CourseType { get; set; }



    }
}
