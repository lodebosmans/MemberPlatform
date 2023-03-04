using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class PersonPersonRelation
    {
        // Attributes
        public int Id { get; set; }
        [ForeignKey("ParentId")]
        public int? ParentId { get; set; }
        [ForeignKey("ChildId")]
        public int? ChildId { get; set; }
        [ForeignKey("RelationId")]
        public int? RelationId { get; set; }        //Foreign key relationship
        

        // Navigation properties
        public Person Parent { get; set; }
        public Person Child { get; set; }
        public Option Relation { get; set; }
    }
}
