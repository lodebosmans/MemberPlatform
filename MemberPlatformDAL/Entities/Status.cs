//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MemberPlatformDAL.Models
//{
//    public class Status
//    {
//        // Attributes
//        public int Id { get; set; }
//        public string Comment { get; set; }
//        [ForeignKey("StatusTypeId")]
//        public int StatusTypeId { get; set; }   //Foreign key relationship
//        public int AgreementId { get; set; }     //Foreign key relationship
//        [ForeignKey("ApproverId")]
//        public int ApproverId { get; set; }        //Foreign key relationship

//        // Navigation properties
//        public Option StatusType { get; set; }    //Navigation property : 1 option per AgreementStatus
//        public PriceAgreement PriceAgreement { get; set; }   //Navigation property : 1 option per AgreementStatus
//        public Person Approver { get; set; }        //Navigation property : 1 Approver(person) per TicketItem

//    }
//}
