using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinkShareEasyLib;
using LinkShareEasyModel;

namespace LinkShareEasy.Lib
{
    public class TokenGetter
    {
        public IToken GetToken(TokenRequest linkRequest)
        {
            return new TokenFactory().GetToken(linkRequest);
        }
    }
}