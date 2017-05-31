using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkShareEasyADO;
using LinkShareEasyModel;

namespace LinkShareEasyLib
{
    public class EnglishWordTokenService : TokenService
    {
        public override LinkShareEasyModel.TokenType TokenType
        {
            get
            {
                return new TokenType() { TokenTypeId = 3, TokenTypeText = "English word" };
            }
        }

        protected override LinkShareEasyModel.IToken GetToken()
        {
            ADOEnglishWordToken aew = new ADOEnglishWordToken();
            IToken token = aew.GetAvailable();
            return token; 
        }

        protected override LinkShareEasyModel.IToken SetUsed(LinkShareEasyModel.IToken token, bool used)
        {
            ADOEnglishWordToken aew = new ADOEnglishWordToken();
            return aew.SetUsed(token.TokenText, true);
        }

        protected override LinkShareEasyModel.IToken UseToken(LinkShareEasyModel.IToken token)
        {
            return SetUsed(token, true);
        }

        protected override bool IsUsed(LinkShareEasyModel.IToken token)
        {
            ADOEnglishWordToken aew = new ADOEnglishWordToken();
            return aew.IsAvailable(token);
        }
    }
       
}
