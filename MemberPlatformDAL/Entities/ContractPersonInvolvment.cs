using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Entities
{
    public class ContractPersonInvolvement
    {
        // Attributes
        public int Id { get; set; }
        public int PersonId { get; set; }          //Foreign key relationship
        public int ContractId { get; set; }        //Foreign key relationship
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }         //Foreign key relationship

        // Navigation properties
        public PersonEntity Person { get; set; }         //Navigation property : 1 person per ContractPersonRole
        public Contract Contract { get; set; }     //Navigation property : 1 Contract per ContractPersonRole
        public Option Role { get; set; }        //Navigation property: 1 Role per ContractRolePerson

    }
}
