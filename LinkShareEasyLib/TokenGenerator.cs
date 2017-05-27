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
        private static List<TokenService> TokenServices 
            = new List<TokenService>(new TokenService[]
        { 
            new NumericTokenService()
            //, new EnglishWordTokenService()
        });

        /// <summary>
        /// Gets token service for the token request.
        /// </summary>
        /// <param name="tokenRequest"></param>
        /// <returns></returns>
        private TokenService GetTokenService(TokenRequest tokenRequest) { return TokenServices.Single(t => t.TokenType.TokenTypeText == tokenRequest.TokenTypeText); }

        /// <summary>
        /// Gets a token that is prepared for storing.
        /// </summary>
        public IToken GetTokenForStore(TokenRequest tokenRequest)
        {
            //Take token from the service.
            IToken serviceToken = GetTokenService(tokenRequest).TakeToken();

            ADOTokenTypeConfiguration attc = new ADOTokenTypeConfiguration();
            TokenTypeConfiguration ttc = attc.Find(serviceToken.TokenType);

            ADODurationDim add = new ADODurationDim();
            //We must add duration data to the token since service does not.
            IToken token = new Token(serviceToken) 
                    {
                        ValidForDuration = ttc.DefaultValidForDuration
                        , ValidForDurationDimId = ttc.DefaultValidForDurationDimId
                    };
            return token;
        }

        /// <summary>
        /// Makes numeric token for a link.
        /// </summary>
        /// <param name="linkHref"></param>
        /// <param name="requestedOn"></param>
        /// <returns></returns>
        public Token MakeNumeric(TokenRequest tokenRequest)
        {
            //TODO: Read https://www.codeproject.com/Articles/690136/All-About-TransactionScope
            using (var ts = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadCommitted}))
            {

                ADONumericToken ant = new ADONumericToken();
                //1. Take available numeric token.
                NumericToken nt = ant.GetAvailable();
                //2. Set numeric token used so nobody could use it again.
                ant.SetUsed(nt.NumericTokenId, true);
 
                ADOToken at = new ADOToken();
                ADOLinkShareEasyConfig alsec = new ADOLinkShareEasyConfig();
                LinkShareEasyConfig lsec = alsec.Find();

                //Insert token.
                Token token = at.Insert(
                    new Token() 
                    {
                        TokenText = nt.TokenText
                        , TokenTypeId = tokenRequest.TokenTypeId
                        , IsExpired = false
                        , ValidForDuration = lsec.DefaultDuration
                        , ValidForDurationDimId = lsec.DefaultDurationDimId
                        , ValidForSeconds = lsec.DefaultDurationSeconds
                    });

                ADOLink al = new ADOLink();
                //Insert link
                Link link = al.Insert(new Link() 
                {
                    LinkHref = tokenRequest.LinkHref
                    , TokenId = tokenRequest.TokenId
                });

                tokenRequest.LinkId = link.LinkId;
                //Update token request

                ADOTokenRequest atr = new ADOTokenRequest();
                atr.UpdateLinkId(tokenRequest);

                ts.Complete();

                return token;
            }
        }
    }
}
