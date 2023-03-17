using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Entities
{
    public class TicketItem
    {
        // Attributes
        public int Id { get; set; }
        public string Message { get; set; }
        public int TicketId { get; set; }        //Foreign key relationship
        [ForeignKey("ReplierId")]
        public int? ReplierId { get; set; }        //Foreign key relationship
        [ForeignKey("ResponsibleId")]
        public int? ResponsibleId { get; set; }     //Foreign key relationship
        [ForeignKey("TicketItemStatusId")]
        public int TicketItemStatusId { get; set; }         //Foreign key relationship
        

        // Navigation properties
        public Ticket Ticket { get; set; }        //Navigation property
        public PersonEntity Replier { get; set; }       //Navigation property : 1 replyer(person) per TicketItem
        public PersonEntity Responsible { get; set; }    //Navigation Property : 1 Responsible(Person) per TicketItem
        public Option TicketItemStatus { get; set; }        //Naviagation property : 1 option per TicketItem
    }
}
