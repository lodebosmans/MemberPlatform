using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int PersonId { get; set; }        //Foreign key relationship
        public Person Person { get; set; }        //Navigation property : 1 person per ticket

        //Navigation property
        //Ticket can be related to 0 or more TicketItem (1 to many relationShip)
        public ICollection<TicketItem> TicketItems { get; set; }


    }
}
