using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class Ticket
    {
        // Attributes
        public int Id { get; set; }
        public int PersonId { get; set; }        //Foreign key relationship

        // Navigation properties

        // 1 person per ticket
        public Person Person { get; set; }        

        // Ticket can be related to 0 or more TicketItem (1 to many relationShip)
        public ICollection<TicketItem> TicketItems { get; set; }


    }
}
