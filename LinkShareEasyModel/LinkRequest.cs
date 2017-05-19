using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShareEasyModel
{
    public class LinkRequest
    {
        public int LinkRequestID { get; set; }
        public DateTime RequestedOn { get; set; }
        public String Token { get; set; }
        public DateTime AvailableUntil { get; set; } 
        public bool Processed { get; set; }
        //Cannot be used and expired.
        public bool Expired { get; set; }
        public bool Used { get; set; }
    }
}
