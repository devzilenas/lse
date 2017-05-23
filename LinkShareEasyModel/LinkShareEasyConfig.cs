using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShareEasyModel
{
    public class LinkShareEasyConfig
    {
        public int TransferAfterDuration { get; set; }
        public int TransferAfterDurationDimId { get; set; }
        public int TransferAfterSeconds { get; set; }
        public int DefaultDurationDimId { get; set; }
        public int DefaultDuration { get; set; }
        public int DefaultDurationSeconds { get; set; }
    }
}
