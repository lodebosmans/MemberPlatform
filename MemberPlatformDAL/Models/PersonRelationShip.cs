using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class PersonRelationship
    {
        public int Id { get; set; }

        [ForeignKey("ParentId")]
        public int? ParentId { get; set; }
        public Person Parent { get; set; }

        [ForeignKey("ChildId")]
        public int? ChildId { get; set; }
        public Person Child { get; set; }


        [ForeignKey("RelationId")]
        public int? RelationId { get; set; }        //Foreign key relationship
        public  Option Relation { get; set; }
    }
}
