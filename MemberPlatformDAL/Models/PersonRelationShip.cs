using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class PersonRelationship
    {
        public int Id { get; set; }


        // Foreign key relationship
        public int RelationShipId { get; set; }
        //Navigation property  1 relationShip per PersonRelationShip
        public Relationship Relationship { get; set; }
    }
}
