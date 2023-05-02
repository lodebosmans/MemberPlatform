using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformCore.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? PriceAgreementStatusId { get; set; }
        public int? PriceAgreementId { get; set; }
        public int PersonId { get; set; }
        public string? Status { get; set; }
    }
}
