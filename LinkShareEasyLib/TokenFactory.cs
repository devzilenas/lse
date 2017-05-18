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
            return new TokenGenerator().MakeNumeric(tokenRequest);
        }
    }

}
