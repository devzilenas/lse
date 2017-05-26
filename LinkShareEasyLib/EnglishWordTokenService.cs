using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShareEasyLib
{
    public class EnglishWordTokenService : TokenService
    {
        public override LinkShareEasyModel.TokenType TokenType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override LinkShareEasyModel.IToken GetToken()
        {
            throw new NotImplementedException();
        }

        protected override LinkShareEasyModel.IToken SetUsed(LinkShareEasyModel.IToken token, bool used)
        {
            throw new NotImplementedException();
        }

        protected override LinkShareEasyModel.IToken UseToken(LinkShareEasyModel.IToken token)
        {
            throw new NotImplementedException();
        }

        protected override bool IsUsed(LinkShareEasyModel.IToken token)
        {
            throw new NotImplementedException();
        }
    }
       
}
