using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkShareEasyModel;
using LinkShareEasyADO;

namespace LinkShareEasyLib
{
    public class TokenFactory
    {
        /// <summary>
        /// Returns a token.
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public IToken GetToken(TokenRequest tokenRequest)
        {
            ADOTokenRequest atr = new ADOTokenRequest(); 
            TokenRequest     tr = atr.Insert(tokenRequest);

            switch (tokenRequest.TokenTypeText)
            {
                case "Numeric":
                        return new TokenGenerator().MakeNumeric(tokenRequest);
                //case "Alpha":
                //        return new TokenGenerator().MakeAlpha(tokenRequest);
                //    break;
                default:
                    throw new NotImplementedException(String.Format("Token type {0}", tokenRequest.TokenTypeText));
            }

        }
    }

}
