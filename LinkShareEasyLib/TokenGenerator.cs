using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connections;
using LinkShareEasyModel;
using LinkShareEasyADO;

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
            ADONumericToken ant = new ADONumericToken();

            //1. Take available numeric token.
            NumericToken nt = ant.GetAvailable(1);

            //2. Make token not appear as available.
            ADONumericTokenUsage antu = new ADONumericTokenUsage();
            NumericTokenUsage ntu = antu.MakeUsed(nt, tokenRequest);

            //3. 
            ADOTokenRequest atr = new ADOTokenRequest();

            return nt; 
        }
    }
}
