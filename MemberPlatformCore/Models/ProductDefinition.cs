namespace MemberPlatformCore.Models
{
    public class ProductDefinition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfSessions { get; set; }
        public int MaxAmountMembers { get; set; }
        public int Price { get; set; }
        public DateTime SubscriptionOpening { get; set; }
        public DateTime SubscriptionClosing { get; set; }
        public string? DayOfWeek { get; set; }
        public int? NumberOfGroups { get; set; }
        public int? ParentProductDefinitionId { get; set; }
        public int ProductDefinitionStatusId { get; set; }
        public int ProductDefinitionFormatId { get; set; }
        //public string ProductDefinitionFormat { get; set; }
        public int ProductDefinitionSportId { get; set; }
        public string? ImageUrl { get; set; }
    }
}
