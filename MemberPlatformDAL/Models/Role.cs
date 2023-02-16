using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class Role
    {
        // Attributes
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation properties
        public ICollection<PersonRole> PersonRoles { get; set; }
    }
}
