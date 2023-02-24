using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class AgreementFormat
    {
        public int Id { get; set; }
        public string Description { get; set; }

        [ForeignKey("Format")]
        public int FormatId { get; set; }
        public Option Format { get; set; }

        public ICollection<Agreement> Agreements { get; set; }
    }
}
