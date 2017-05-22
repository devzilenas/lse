using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShareEasyModel
{
    public class LinkRequest
    {
        public int LinkRequestId { get; set; }
        public DateTime RequestedOn { get; set; }
        public String Token { get; set; }
        public bool Processed { get; set; }
    }
}
