using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkShareEasyModel;

namespace LinkShareEasyADO
{
    public class ADOToken
    {
        public Token Insert(Token token)
        {
            using (var c = Connections.GetConnections.GetConnection())
            using (var cmd = c.CreateCommand())
            {
                c.Open();

                cmd.CommandText = "INSERT INTO Tokens (TokenText, TokenTypeId) VALUES (@1, @2); SELECT SCOPE_IDENTITY()";
                cmd.Parameters.AddWithValue("@1", token.TokenText);
                cmd.Parameters.AddWithValue("@2", token.TokenTypeId);

                return new Token()
                { 
                    TokenId = Convert.ToInt32(cmd.ExecuteScalar())
                    , TokenText = token.TokenText
                    , TokenTypeId = token.TokenTypeId
                }; 
            }
        }
    }
}
