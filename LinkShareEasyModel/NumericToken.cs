using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShareEasyModel
{
    public class NumericToken : IToken
    {
        public long NumericTokenID { get; set; }
        public long NumericTokenText { get; set; }
        public bool Used { get; set; }

        public string TokenText { get { return Convert.ToString(NumericTokenText); } }
    }
}
