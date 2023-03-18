using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Entities
{
    public class ProductUnitEntity
    {
        // Attributes
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public DateTime StartTimeScheduled { get; set; }
        public DateTime EndTimeScheduled { get; set; }
        public DateTime StartTimeActual { get; set; }
        public DateTime EndTimeActual { get; set; }
        public int AddressId { get; set; }

        [ForeignKey("ProductUnitStatusId")]
        public int ProductUnitStatusId { get; set; }        //Foreign key relationship

        // Navigation properties
        public ProductDefinitionEntity? Product { get; set; }
        public OptionEntity? ProductUnitStatus { get; set; }
        public AddressEntity? Address { get; set; }


    }
}