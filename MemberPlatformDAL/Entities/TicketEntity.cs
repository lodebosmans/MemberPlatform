namespace MemberPlatformDAL.Entities
{
    public class TicketEntity
    {
        // Attributes
        public int Id { get; set; }

        public int PersonId { get; set; }        //Foreign key relationship

        // Navigation properties

        // 1 person per ticket
        public PersonEntity Person { get; set; }

        // Ticket can be related to 0 or more TicketItem (1 to many relationShip)
        public ICollection<TicketItemEntity> TicketItems { get; set; }
    }
}
