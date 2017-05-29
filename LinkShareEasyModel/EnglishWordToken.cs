using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkShareEasyModel;

namespace LinkShareEasyModel
{
    public class EnglishWordToken : IToken
    {
        public int EnglishWordTokenId { get; set; }
        public String EnglishWordTokenText { get; set; }
        public bool Used { get; set; }
        public bool IsExpired { get; set; }

        public TokenType TokenType { get; set; }
        public int TokenTypeId { get; set; }

        public int TokenId { get { return EnglishWordTokenId; } set { EnglishWordTokenId= value; } }
        public string TokenText { get { return EnglishWordTokenText; } }

        public int ValidForDurationDimId { get; set; }

        public int ValidForDuration { get; set; }
        public int ValidForSeconds { get; set; }
    }
}
