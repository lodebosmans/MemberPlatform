
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class CourseOffer
    {
        public int Id { get; set; }

        //Foreign key relationship
        public int OfferId { get; set; }
        //NavigationProperty : 1 Offer per CourseOffer
        public Offer Offer { get; set; }

        //Foreign key relationship
        public int CourseId { get; set; }
        //Navigation Property : 1 Course per CourseOffer
        public Course Course { get; set; }

    }
}
