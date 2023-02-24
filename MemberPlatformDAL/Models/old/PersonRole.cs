using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class PersonRole
    {
        // Attributes
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int RoleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }   

        // Navigation properties
        public Role Role { get; set; } 
        public Person Person { get; set; }

    }
}
