using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class Offer
    {
        // Attributes
        public int Id { get; set; }
        public string Description { get; set; }

        // Navigation properties
        ICollection<Person> Persons { get; set; }
        ICollection<CourseOffer> CourseOffers { get; set; }

    }
}
