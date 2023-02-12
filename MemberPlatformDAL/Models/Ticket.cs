using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int PersonId { get; set; }

    }
}
