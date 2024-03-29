using MemberPlatformDAL.UoW;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemberPlatformDAL.Entities
{
    public class ProductDefinitionEntity : IEntity
    {
        // Attributes
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

        // Self-referencing foreign key property
        public int? ParentProductDefinitionId { get; set; }

        [ForeignKey("ProductDefinitionStatusId")]
        public int ProductDefinitionStatusId { get; set; }        //Foreign key relationship

        [ForeignKey("ProductDefinitionFormatId")]
        public int ProductDefinitionFormatId { get; set; }

        [ForeignKey("ProductDefinitionSportId")]
        public int ProductDefinitionSportId { get; set; }

        public string? ImageUrl { get; set; }

        // Navigation properties
        public ICollection<ProductAgreementEntity>? ProductAgreements { get; set; }

        public ICollection<ProductUnitEntity>? ProductUnits { get; set; }
        public virtual ProductDefinitionEntity? ParentProductDefinition { get; set; }  // This is the self-referential property
        public virtual ICollection<ProductDefinitionEntity>? ChildProductDefinitions { get; set; } // One-to-many relationship with child categories

        //= new List<ProductDefinition>();
        public OptionEntity? ProductDefinitionStatus { get; set; }

        public OptionEntity? ProductDefinitionFormat { get; set; }
        public OptionEntity? ProductDefinitionSport { get; set; }
    }
}
