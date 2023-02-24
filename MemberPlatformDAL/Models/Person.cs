using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string? Box { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string InsuranceCompany { get; set; }
        public string MobilePhone { get; set; }
        public string EmailAddress { get; set; }
        public string IdentityNumber { get; set; }
        public int OfferId { get; set; }

        // public int EnrollmentStatusId { get; set; }
        public bool PrivacyApproval { get; set; }
        //Foreign key relationship
        public int OptionId { get; set; }
        //Navigation property: 1 option per Person
        public Option Option { get; set; }


        //// Navigation properties
        public ICollection<ContractPersonRole> contractPersonRoles { get; set; }

        [InverseProperty("Approver")]
        public ICollection<AgreementStatus> AgreementStatusesApprover { get; set; }

        [InverseProperty("Parent")]
        public ICollection<PersonRelationship> PersonRelationshipsParent { get; set; }

        [InverseProperty("Child")]
        public ICollection<PersonRelationship> PersonRelationshipsChild { get; set; }



        //public ICollection<SalesItem> SaleItems { get; set; }
        //public ICollection<InvoicePaymentStatus> InvoicePaymentStatuses { get; set; }
        //public ICollection<PersonCourse> PersonCoursesMember { get; set; }
        //public ICollection<PersonCourse> PersonCoursesSubmitter { get; set; }
        //public ICollection<PersonRelationship> PersonRelationshipsParent { get; set; }
        //public ICollection<PersonRelationship> PersonRelationshipsChild { get; set; }
        //public ICollection<PersonCourseEnrollmentStatus> PersonCourseEnrollmentStatuses { get; set; }
        //public ICollection<CourseSessionTrainer> CourseSessionTrainers { get; set; }
        //public ICollection<TrainerCourse> TrainerCourses { get; set; }
        //public ICollection<PersonRole> PersonRoles { get; set; }
        //public ICollection<Ticket> Tickets { get; set; }
        //[InverseProperty("Replyer")]
        //public ICollection<TicketItem> TicketItemsReplier { get; set; }
        //[InverseProperty("Responsible")]
        //public ICollection<TicketItem> TicketItemsResponsible { get; set; }
        //public ICollection<CourseSessionStatus> CourseSessionStatuses { get; set; }
        //public ICollection<CourseStatus> CourseStatuses { get; set; }
        //public ICollection<PaymentStatus> PaymentStatuses { get; set; }
        //public Offer Offer { get; set; }

    }
}
