using LinkShareEasyLib;
using LinkShareEasyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkShareEasy.Lib
{
    public class TokenServices
    {
        private static List<TokenService> TokenServicesList
        = new List<TokenService>(new TokenService[]
        { 
            new NumericTokenService()
            , new EnglishWordTokenService()
        });

        /// <summary>
        /// Gets token service for the token request.
        /// </summary>
        /// <param name="tokenRequest"></param>
        /// <returns></returns>
        public TokenService GetTokenService(TokenRequest tokenRequest)
        { 
            return TokenServicesList.Single(t => t.TokenType.TokenTypeText == tokenRequest.TokenTypeText);
        }
 
        public TokenService GetTokenService(TokenType tt)
        {
            return TokenServicesList.Single(t => t.TokenType.Equals(tt));
        }
    }
}