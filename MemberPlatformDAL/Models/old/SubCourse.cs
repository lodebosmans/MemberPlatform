using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class SubCourse
    {
        public int Id { get; set; }
        //Foreign key relationship
        public int CourseId { get; set; }
        //Navigation Property : 1 parent Course per subCourse
        public Course ParentCourse { get; set; }

        //Navigation property : 1 Child Course per subCourse
        public Course ChildCourse { get; set; }

    }
}
