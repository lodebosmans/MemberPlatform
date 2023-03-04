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
        public string HouseNumber { get; set; }
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
        public bool PrivacyApproval { get; set; }


        //// Navigation properties
        public ICollection<ContractPersonInvolvement> ContractPersonInvolvements { get; set; }

        //[InverseProperty("Approver")]
        //public ICollection<Status> AgreementStatusesApprover { get; set; }

        [InverseProperty("Parent")]
        public ICollection<PersonPersonRelation> PersonPersonRelationsParent { get; set; }

        [InverseProperty("Child")]
        public ICollection<PersonPersonRelation> PersonPersonRelationsChild { get; set; }

        [InverseProperty("Approver")]
        public ICollection<PriceAgreement> PriceAgreementApprover { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
        [InverseProperty("Responsible")]
        public ICollection<TicketItem> TicketItemsResponsible { get; set; }

        [InverseProperty("Replier")]
        public ICollection<TicketItem> TicketItemsReplier { get; set; }

        public ICollection<SalesItem> SalesItems { get; set; }

    }
}
