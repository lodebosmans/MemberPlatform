using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class RelationShip
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation property
        //RelationShip can be related to 0 or more PersonRelationShips (1 to many relationShip)
        public ICollection<PersonRelationShip> PersonRelationShips { get; set; }
    }
}
