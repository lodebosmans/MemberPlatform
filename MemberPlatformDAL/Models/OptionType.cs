using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Models
{
    public class OptionType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation property
        //OptionType can be related to 0 or more option (1 to many relationShip)
        public ICollection<Option> options { get; set; }

    }
}
