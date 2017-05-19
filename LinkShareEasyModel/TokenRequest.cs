using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShareEasyModel
{
    public class TokenRequest
    {
        public int TokenRequestId { get; set; }
        public DateTime RequestedOn { get; set; }
        public int LinkId { get; set; }
        public String LinkHref { get; set; }
        public int TokenId { get; set; }
        public int TokenTypeId { get; set; }
        public String TokenTypeText { get; set; }
    }
}
