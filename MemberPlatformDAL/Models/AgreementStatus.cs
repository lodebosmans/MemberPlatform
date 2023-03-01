using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class AgreementStatus
    {
        public int Id { get; set; }
        public string Comment { get; set; }

        [ForeignKey("StatusId")]
        public int? StatusId { get; set; }   //Foreign key relationship  
        public Option Status { get; set; }    //Navigation property : 1 option per AgreementStatus

        public int? AgreementId { get; set; }     //Foreign key relationship
        public Agreement Agreement { get; set; }   //Navigation property : 1 option per AgreementStatus


        [ForeignKey("ApproverId")]
        public int? ApproverId { get; set; }        //Foreign key relationship
        public Person Approver { get; set; }        //Navigation property : 1 Approver(person) per TicketItem


    }
}
