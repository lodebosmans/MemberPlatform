using MemberPlatformDAL.UoW;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemberPlatformDAL.Entities
{
    public class ProductUnitEntity : IEntity
    {
        // Attributes
        public int Id { get; set; }

        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public TimeSpan StartTimeScheduled { get; set; }
        public TimeSpan EndTimeScheduled { get; set; }
        public TimeSpan? StartTimeActual { get; set; }
        public TimeSpan? EndTimeActual { get; set; }
        public int AddressId { get; set; }

        [ForeignKey("ProductUnitStatusId")]
        public int ProductUnitStatusId { get; set; }        //Foreign key relationship

        // Navigation properties
        public ProductDefinitionEntity? Product { get; set; }

        public OptionEntity? ProductUnitStatus { get; set; }
        public AddressEntity? Address { get; set; }
    }
}
