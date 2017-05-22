using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShareEasyModel
{
    public class Token : IToken
    {
        public int TokenId { get; set; }
        public String TokenText { get; set; }
        public int TokenTypeId { get; set; }
        public int ValidForDurationDimId { get; set; }
        public int ValidForDuration { get; set; }
        public int ValidForDurationSeconds { get; set; }
        public bool IsExpired { get; set; }
    }
}
