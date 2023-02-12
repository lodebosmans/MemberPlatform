using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class Person
    {
        // Attributes
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //// Navigation properties
        //public ICollection<Answer> Answers { get; set; }
    }
}
