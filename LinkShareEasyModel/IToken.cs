using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShareEasyModel
{
    public interface IToken
    { 
        int TokenId { get; set; }
        String TokenText { get; }
        int TokenTypeId {get; set;}
        TokenType TokenType { get; set;        }
        int ValidForDurationDimId { get; set; }
        int ValidForDuration { get; set; }
        int ValidForSeconds { get; set; }
        bool IsExpired { get; set; }
    }
}
