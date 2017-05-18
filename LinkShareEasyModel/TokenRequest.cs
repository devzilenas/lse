using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShareEasyModel
{
    public class TokenRequest
    {
        public long TokenRequestId { get; set; }
        public DateTime RequestedOn { get; set; }
        public long LinkId { get; set; }
        public String LinkHref { get; set; }
        public long TokenID { get; set; }
    }
}
