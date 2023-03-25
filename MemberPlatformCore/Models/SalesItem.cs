namespace MemberPlatformCore.Models
{
    public class SalesItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime EndDate { get; set; }
        public int SalesItemTypeId { get; set; }
        public int PersonId { get; set; }
    }
}
