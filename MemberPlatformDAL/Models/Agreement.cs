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
        // Attributes
        public int Id { get; set; }
        public string StructuredMessage { get; set; }
        public DateTime PaymentDate { get; set; }
        [ForeignKey("ContractId")]
        public int ContractId { get; set; }         //Foreign key relationship
        [ForeignKey("AgreementSportId")]
        public int AgreementSportId { get; set; }         //Foreign key relationship
        [ForeignKey("AgreementFormatId")]
        public int AgreementFormatId { get; set; }         //Foreign key relationship
        [ForeignKey("AgreementProductId")]
        public int AgreementProductId { get; set; }         //Foreign key relationship

        // Navigation properties
        public Contract Contract { get; set; }        //Navigation property: 1 Contract per Agreement
        public AgreementSport AgreementSport { get; set; }        //Navigation property: 1 AgrrementSport per Agreement
        public AgreementFormat AgreementFormat { get; set; }        //Navigation property: 1 AgrrementSport per Agreement
        public AgreementProduct AgreementProduct { get; set; }        //Navigation property: 1 AgrrementSport per Agreement
        public ICollection<AgreementDiscount> AgreementDiscounts { get; set; }
        public ICollection<AgreementStatus> AgreementStatuses { get; set; }
    }
}
