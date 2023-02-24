using MemberPlatformDAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class CourseType
    {
        public int Id { get; set; }
        public string Name { get; set; }


        //Navigation property
        //CourseType can be related to 0 or more Course (1 to many relationShip)
        public ICollection<Course> Courses { get; set; }
    }
}
