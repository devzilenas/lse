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
        public TokenType TokenType { get; set; }
        public int TokenTypeId { get; set; }
        public int TokenId { get { return NumericTokenId; } set { NumericTokenId = value; } }
        public bool IsExpired { get; set; }

        public string TokenText { get { return Convert.ToString(NumericTokenN); } } 

        public int ValidForDurationDimId {get;set;}

        public int ValidForDuration { get; set; }
        public int ValidForSeconds { get; set; }
    }
}
