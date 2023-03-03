using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class ProductUnit
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public string Location { get; set; }
        public DateTime StartTimeScheduled { get; set; }
        public DateTime EndTimeScheduled { get; set; }
        public DateTime StartTimeActual { get; set; }
        public DateTime EndTimeActual { get; set; }

        [ForeignKey("unitStatusId")]
        public int UnitStatusId { get; set; }        //Foreign key relationship
        public Option UnitStatus { get; set; }






    }
}
