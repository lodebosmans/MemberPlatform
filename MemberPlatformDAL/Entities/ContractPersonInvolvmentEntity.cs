using System.ComponentModel.DataAnnotations.Schema;

namespace MemberPlatformDAL.Entities
{
    public class ContractPersonInvolvementEntity
    {
        // Attributes
        public int Id { get; set; }

        public int PersonId { get; set; }          //Foreign key relationship
        public int ContractId { get; set; }        //Foreign key relationship

        [ForeignKey("RoleId")]
        public int RoleId { get; set; }         //Foreign key relationship

        // Navigation properties
        public PersonEntity Person { get; set; }         //Navigation property : 1 person per ContractPersonRole

        public ContractEntity Contract { get; set; }     //Navigation property : 1 Contract per ContractPersonRole
        public OptionEntity Role { get; set; }        //Navigation property: 1 Role per ContractRolePerson
    }
}
