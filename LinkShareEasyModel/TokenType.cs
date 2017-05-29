using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShareEasyModel
{
    public class TokenType
    {
        public int TokenTypeId { get; set; }
        public String TokenTypeText { get; set; }

        public override bool Equals(object obj)
        {
            return TokenTypeText == ((TokenType)obj).TokenTypeText;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
