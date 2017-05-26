using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkShareEasyModel;
using LinkShareEasyADO;

namespace LinkShareEasyLib
{
    public class NumericTokenService : TokenService
    {

        public override LinkShareEasyModel.TokenType TokenType
        {
            get
            {
                return new TokenType
                { 
                     TokenTypeId = 1
                     , TokenTypeText = "Numeric"
                };
            }
        }

        protected override LinkShareEasyModel.IToken GetToken()
        {
            ADONumericToken ant = new ADONumericToken();
            IToken token = ant.GetAvailable();
            //Add token type 
            token.TokenType = TokenType;
            return token;
        }

        protected override LinkShareEasyModel.IToken SetUsed(LinkShareEasyModel.IToken token, bool used)
        { 
            ADONumericToken ant = new ADONumericToken();
            return ant.SetUsed(token, used);
        }

        protected override LinkShareEasyModel.IToken UseToken(LinkShareEasyModel.IToken token)
        {
            return SetUsed(token, true);
        }

        protected override bool IsUsed(LinkShareEasyModel.IToken token)
        {
            ADONumericToken ant = new ADONumericToken();
            return ant.IsAvailable(token);
        }
    }
}
