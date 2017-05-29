using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkShareEasyModel;

namespace LinkShareEasyLib
{
    public abstract class TokenService : ITokenService
    {
        abstract public TokenType TokenType { get; }

        /// <summary>
        /// Takes a token.
        /// </summary>
        public IToken TakeToken()
        {
            IToken token = GetToken();
            token.TokenType = TokenType;
            UseToken(token);
            return token;
        }

        /// <summary>
        /// Returns tokens to the available tokens pool.
        /// </summary>
        /// <returns>True if token is made </returns>
        /// <param name="token"></param>
        public bool ReturnToken(IToken token)
        {
            UnuseToken(token);
            return IsAvailable(token);
        }

        private void UnuseToken(IToken token)
        {
            SetUsed(token, false);
        }

        /// <summary>
        /// Returns non used token.
        /// </summary>
        protected abstract IToken GetToken();

        /// <summary>
        /// Sets used for token.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="used"></param>
        /// <returns></returns>
        protected abstract IToken SetUsed(IToken token, bool used);

        /// <summary>
        /// Sets token as used.
        /// </summary>
        protected abstract IToken UseToken(IToken token);

        /// <summary>
        /// Checks token for usage.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        protected abstract bool IsUsed(IToken token);

        /// <summary>
        /// Is the token available?
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        protected bool IsAvailable(IToken token) { return !IsUsed(token);  } 
    }
}