using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class TicketItem
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int? TicketId { get; set; }        //Foreign key relationship
        public Ticket Ticket { get; set; }        //Navigation property

        //[ForeignKey("Replier")]
        //public int? ReplierId { get; set; }        //Foreign key relationship
        //public Person Replier { get; set; }       //Navigation property : 1 replyer(person) per TicketItem

        //[ForeignKey("Responsible")]
        //public int? ResponsibleId { get; set; }     //Foreign key relationship

        //public Person Responsible { get; set; }    //Navigation Property : 1 Responsible(Person) per TicketItem


        public int OptionId { get; set; }         //Foreign key relationship
        public Option Option { get; set; }        //Naviagation property : 1 option per TicketItem




    }
}
