using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class AgreementSport
    {
        public int Id { get; set; }
        public string Description { get; set; }

        [ForeignKey("SportId")]
        public int SportId { get; set; }
        public Option Sport { get; set; }

        public ICollection<Agreement> Agreements { get; set; }
    }
}
