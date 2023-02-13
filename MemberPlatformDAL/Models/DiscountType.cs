using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class DiscountType
    {
        public int Id { get; set; }
        public string DiscountName { get; set; }
        public string Type { get; set; }


        //Navigation property
        //DiscountType can be related to 0 or more Invoice (1 to many relationShip)
        public ICollection<Invoice> Invoices { get; set; }


        //Navigation property
        //RelationShip can be related to 0 or more PersonRelationShips (1 to many relationShip)
        public ICollection<PersonCourse> PersonCourses { get; set; }
    }
}
