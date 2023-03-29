using MemberPlatformDAL.UoW;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemberPlatformDAL.Entities
{
    public class TicketItemEntity : IEntity
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
        public TicketEntity Ticket { get; set; }        //Navigation property

        public PersonEntity Replier { get; set; }       //Navigation property : 1 replyer(person) per TicketItem
        public PersonEntity Responsible { get; set; }    //Navigation Property : 1 Responsible(Person) per TicketItem
        public OptionEntity TicketItemStatus { get; set; }        //Naviagation property : 1 option per TicketItem
    }
}
