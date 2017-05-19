using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShareEasyModel
{
    public class TokenUsage
    {
        public int TokenUsageId { get; set; }
        public int TokenId { get; set; }
        public String Token { get; set; }
        public DateTime? UsedOn { get; set; }
    }
}
