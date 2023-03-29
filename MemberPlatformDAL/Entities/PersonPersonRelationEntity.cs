using MemberPlatformDAL.UoW;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemberPlatformDAL.Entities
{
    public class PersonPersonRelationEntity : IEntity
    {
        // Attributes
        public int Id { get; set; }

        [ForeignKey("ParentId")]
        public int? ParentId { get; set; }

        [ForeignKey("ChildId")]
        public int? ChildId { get; set; }

        [ForeignKey("RelationId")]
        public int? RelationId { get; set; }        //Foreign key relationship

        // Navigation properties
        public PersonEntity Parent { get; set; }

        public PersonEntity Child { get; set; }
        public OptionEntity Relation { get; set; }
    }
}
