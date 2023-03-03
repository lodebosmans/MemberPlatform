using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class Product
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

        [ForeignKey("ProductStatusID")]
        public int ProductStatusId { get; set; }        //Foreign key relationship
        public int? ParentProductId { get; set; }
        

        // Navigation properties
        public ICollection<AgreementProduct> AgreementProducts { get; set; }
        public ICollection<ProductUnit> ProductUnits { get; set; }
        public Option ProductStatus { get; set; }
        public Product ParentProduct { get; set; }






    }
}
