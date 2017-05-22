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
        public IToken MakeNumeric(TokenRequest tokenRequest)
        {
            //TODO: Read https://www.codeproject.com/Articles/690136/All-About-TransactionScope
            using (var ts = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.Serializable }))
            {

                ADONumericToken ant = new ADONumericToken();
                //1. Take available numeric token.
                NumericToken nt = ant.GetAvailable(1);
                //2. Set numeric token used so nobody could use it again.
                ant.SetUsed(nt.NumericTokenId, true);
 
                ADOToken at = new ADOToken();
                Token token = at.Insert(
                    new Token() 
                    {
                        TokenText = nt.TokenText
                        , TokenTypeId = tokenRequest.TokenTypeId
                        , IsExpired = false
                        , ValidForDuration = new ADOLinkShareEasyConfig().Find().
                    });

                ADOLink al = new ADOLink();
                Link link = al.Insert(new Link() {LinkHref = tokenRequest.LinkHref, TokenId = tokenRequest.TokenId});
                al.Insert(link);

                ts.Complete();

                return token;
            }
        }
    }
}
