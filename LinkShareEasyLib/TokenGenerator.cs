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
                NumericToken nt = ant.GetAvailable(1);
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
                        , ValidForDurationSeconds = lsec.DefaultDurationSeconds
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
