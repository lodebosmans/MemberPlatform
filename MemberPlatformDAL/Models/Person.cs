using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class Person
    {
        // Attributes
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string HouseBox { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string InsuranceCompany { get; set; }
        public string MobilePhone { get; set; }
        public string EmailAddress { get; set; }
        public string IdentityNumber { get; set; }
        public int GroupId { get; set; }

        // public int EnrollmentStatusId { get; set; }
        public bool PrivacyApproval { get; set; }


        //// Navigation properties
        public ICollection<SaleItem> SaleItems { get; set; }
        public ICollection<InvoicePaymentStatus> InvoicePaymentStatuses { get; set; }
        public ICollection<PersonCourse> PersonCoursesMember { get; set; }
        public ICollection<PersonCourse> PersonCoursesSubmitter { get; set; }
        public ICollection<PersonRelationship> PersonRelationshipsParent { get; set; }
        public ICollection<PersonRelationship> PersonRelationshipsChild { get; set; }
        public ICollection<PersonCourseEnrollmentStatus> PersonCourseEnrollmentStatuses { get; set; }
        public ICollection<CourseSessionTrainer> CourseSessionTrainers { get; set; }
        public ICollection<TrainerCourse> TrainerCourses { get; set; }
        public ICollection<PersonRole> PersonRoles { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<TicketItem> TicketItemsReplier { get; set; }
        public ICollection<TicketItem> TicketItemsResponsible { get; set; }




    }
}
