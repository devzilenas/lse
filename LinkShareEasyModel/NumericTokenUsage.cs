using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShareEasyModel
{
    public class NumericTokenUsage
    {
        public long NumericTokenUsageId { get; set; }
        public long LinkId { get; set; }
        public DateTime UsedOn { get; set; }
        public long NumericTokenId { get; set; }
    }
}
