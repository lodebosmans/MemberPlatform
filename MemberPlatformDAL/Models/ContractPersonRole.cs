using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class ContractPersonRole
    {
        public int Id { get; set; }

        public int? PersonId { get; set; }          //Foreign key relationship
        public Person Person { get; set; }         //Navigation property : 1 person per ContractPersonRole

        public int? ContractId { get; set; }        //Foreign key relationship
        public Contract Contract { get; set; }     //Navigation property : 1 Contract per ContractPersonRole

        [ForeignKey("RoleId")]
        public int? RoleId { get; set; }         //Foreign key relationship
        public Option Role { get; set; }        //Navigation property: 1 Role per ContractRolePerson
    }
}
