using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShareEasyModel
{
    public class NumericToken : IToken
    {
        public int NumericTokenId { get; set; }
        public int NumericTokenN { get; set; }
        public bool Used { get; set; }

        public string TokenText { get { return Convert.ToString(NumericTokenN); } }
    }
}
