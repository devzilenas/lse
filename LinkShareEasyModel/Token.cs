using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShareEasyModel
{
    public class Token : IToken
    {
        public Token() { }
        public Token(IToken token) { FromIToken(token); }
        public int TokenId { get; set; }
        public String TokenText { get; set; }
        public int TokenTypeId { get; set; }
        public int ValidForDurationDimId { get; set; }
        public int ValidForDuration { get; set; }
        public int ValidForSeconds { get; set; }
        public bool IsExpired { get; set; }

        public bool SingleUse { get; set; }

        public TokenType TokenType
        {
            get { return new TokenType() { TokenTypeId = TokenTypeId }; }
            set
            {
                TokenTypeId = value.TokenTypeId;
            }
        }

        private void FromIToken(IToken token)
        {
            this.TokenId = token.TokenId;
            this.TokenText = token.TokenText;
            this.TokenType = token.TokenType;
            this.IsExpired = token.IsExpired;
            this.ValidForSeconds = token.ValidForSeconds;
            this.ValidForDuration = token.ValidForDuration;
            this.ValidForDurationDimId = token.ValidForDurationDimId;
        }
    }
}
