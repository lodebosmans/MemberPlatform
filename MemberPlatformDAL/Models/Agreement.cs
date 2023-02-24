using System;
using System.Collections.Generic;
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

    }
}
