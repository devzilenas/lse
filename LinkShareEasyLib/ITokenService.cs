using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinkShareEasyModel;


namespace LinkShareEasyLib
{
    public interface ITokenService
    {
        IToken TakeToken();
        bool ReturnToken(IToken token);
    }
}
