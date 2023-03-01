using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class Agreement
    {
        public int Id { get; set; }
        public string StructuredMessage { get; set; }
        public DateTime PaymentDate { get; set; }

        [ForeignKey("ContractId")]
        public int? ContractId { get; set; }         //Foreign key relationship
        public Contract Contract { get; set; }        //Navigation property: 1 Contract per Agreement

        [ForeignKey("AgreementSportId")]
        public int? AgreementSportId { get; set; }         //Foreign key relationship
        public AgreementSport AgreementSport { get; set; }        //Navigation property: 1 AgrrementSport per Agreement

        [ForeignKey("AgreementFormatId")]
        public int? AgreementFormatId { get; set; }         //Foreign key relationship
        public AgreementFormat AgreementFormat { get; set; }        //Navigation property: 1 AgrrementSport per Agreement

        [ForeignKey("AgreementProductId")]
        public int? AgreementProductId { get; set; }         //Foreign key relationship
        public AgreementProduct AgreementProduct { get; set; }        //Navigation property: 1 AgrrementSport per Agreement

        public ICollection<AgreementDiscount> AgreementDiscounts { get; set; }

        public ICollection<AgreementStatus> AgreementStatuses { get; set; }
    }
}
