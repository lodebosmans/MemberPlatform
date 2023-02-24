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

        [ForeignKey("Parent")]
        public int? ParentId { get; set; }
        public Person Parent { get; set; }

        [ForeignKey("Child")]
        public int? ChildId { get; set; }
        public Person Child { get; set; }


        [ForeignKey("Relation")]
        public int? RelationId { get; set; }        //Foreign key relationship
        public  Option Relation { get; set; }
    }
}
