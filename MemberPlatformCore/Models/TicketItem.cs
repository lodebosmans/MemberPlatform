namespace MemberPlatformCore.Models
{
    public class TicketItem
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int TicketId { get; set; }
        public int? ReplierId { get; set; }
        public int? ResponsibleId { get; set; }
        public int TicketItemStatusId { get; set; }
    }
}
