using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkShareEasy.Lib
{
    public class LinkRequest
    {
        public String LinkHref { get; set; }
        public DateTime RequestedOn { get; set; }

        internal static LinkRequest Request(string p)
        {
            return new LinkRequest() { LinkHref = p, RequestedOn = DateTime.Now };
        }
    }
}
