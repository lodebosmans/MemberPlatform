using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Entities
{
    public class Address
    {
        // Attributes
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string? Box { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        [ForeignKey("AddressTypeId")]
        public int? AddressTypeId { get; set; }

        // Navigation properties
        public Option? AddressType { get; set; }
        public ICollection<ProductUnit>? productUnits { get; set; }
        public ICollection<PersonEntity>? persons { get; set; }


    }
}
