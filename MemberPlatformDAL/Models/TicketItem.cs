using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class TicketItem
    {
        public int Id { get; set; }
        public string Message { get; set; }
        //Foreign key relationship
        public int TicketId { get; set; }
        //Navigation property
        public Ticket Ticket { get; set; }

        //Foreign key relationship
        public int PersonId { get; set; }
        //Navigation property : 1 replyer(person) per TicketItem
        public Person Replyer { get; set; }

        //Navigation Property : 1 Responsible(Person) per TicketItem
        public Person Responsible { get; set; }


        
    }
}
