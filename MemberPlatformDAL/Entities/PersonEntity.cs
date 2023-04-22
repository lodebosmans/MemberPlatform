using MemberPlatformDAL.UoW;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemberPlatformDAL.Entities
{
    public class PersonEntity : IEntity
    {
        // Attributes
        public int Id { get; set; }
        public bool PrivacyApproval { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int AddressId { get; set; }
        [EmailAddress]
        [Required]
        public string EmailAddress { get; set; }
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public string IdentityNumber { get; set; }
        public string LastName { get; set; }
        public string MobilePhone { get; set; }
        public string? InsuranceCompany { get; set; }

        // Attributes for registration
        //public byte[]? PasswordSalt { get; set; }
        //public byte[]? PasswordHash { get; set; }
        //public string Token { get; set; }
        //public DateTime TokenCreated { get; set; }
        //public DateTime TokenExpires { get; set; }



        // Navigation properties
        public AddressEntity? Address { get; set; }
        public ICollection<ContractPersonInvolvementEntity>? ContractPersonInvolvements { get; set; }

        //[InverseProperty("Approver")]
        //public ICollection<Status> AgreementStatusesApprover { get; set; }

        [InverseProperty("Parent")]
        public ICollection<PersonPersonRelationEntity>? PersonPersonRelationsParent { get; set; }

        [InverseProperty("Child")]
        public ICollection<PersonPersonRelationEntity>? PersonPersonRelationsChild { get; set; }

        [InverseProperty("Approver")]
        public ICollection<PriceAgreementEntity>? PriceAgreementApprover { get; set; }

        public ICollection<TicketEntity>? Tickets { get; set; }

        [InverseProperty("Responsible")]
        public ICollection<TicketItemEntity>? TicketItemsResponsible { get; set; }

        [InverseProperty("Replier")]
        public ICollection<TicketItemEntity>? TicketItemsReplier { get; set; }

        public ICollection<SalesItemEntity>? SalesItems { get; set; }
    }
}
