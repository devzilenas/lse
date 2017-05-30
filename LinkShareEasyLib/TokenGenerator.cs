using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connections;
using LinkShareEasyModel;
using LinkShareEasyADO;
using System.Transactions;

namespace LinkShareEasyLib
{
    public class TokenGenerator
    { 
        /// <summary>
        /// Gets a token that is prepared for storing.
        /// </summary>
        public IToken GetTokenForStoring(TokenService tokenService, TokenRequest tokenRequest)
        {
            //Take token from the service.
            IToken serviceToken = tokenService.TakeToken();

            ADOTokenTypeConfiguration attc = new ADOTokenTypeConfiguration();
            TokenTypeConfiguration ttc = attc.Find(serviceToken.TokenType);

            ADODurationDim add = new ADODurationDim();
            //We must add duration data to the token since service does not.
            IToken token = new Token(serviceToken) 
                    {
                        ValidForDuration = ttc.DefaultValidForDuration
                        , ValidForDurationDimId = ttc.DefaultValidForDurationDimId
                        , SingleUse = tokenRequest.SingleUse
                    };
            return token;
        }
    }
}
