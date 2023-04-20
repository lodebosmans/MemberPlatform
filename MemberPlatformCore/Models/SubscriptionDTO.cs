using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformCore.Models
{
    public class SubscriptionDTO
    {
        public Contract Contract { get; set; }
        public ProductAgreement ProductAgreement { get; set; }
        public PriceAgreement PriceAgreement { get; set; }
        public ContractPersonInvolvement ContractPersonInvolvement { get; set; }

    }
}
