namespace MemberPlatformDAL.Entities
{
    public class SalesItemEntity
    {
        // Attributes
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime EndDate { get; set; }
        public int SalesItemTypeId { get; set; }
        public int PersonId { get; set; }

        // Navigation properties
        public PersonEntity Person { get; set; }        //Navigation property : 1 person per SaleItem

        public OptionEntity SalesItemType { get; set; }
    }
}
