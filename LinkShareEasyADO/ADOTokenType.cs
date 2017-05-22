using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkShareEasyModel;

namespace LinkShareEasyADO
{
    public class ADOTokenType
    { 
        public TokenType ById(int id)
        {
            return All().First(t => t.TokenTypeID == id);
        }

        /// <summary>
        /// Gets all token types.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TokenType> All()
        {
            using (var c = Connections.GetConnections.GetConnection())
            using (var cmd = c.CreateCommand())
            {
                cmd.CommandText = "SELECT TokenTypeID, TokenTypeText FROM TokenTypes"; 
                using (var reader = cmd.ExecuteReader())
                while (reader.HasRows && reader.Read())
                {
                    yield return 
                        new TokenType
                        { 
                            TokenTypeID = reader.GetInt32(reader.GetOrdinal("TokenTypeID"))
                            , TokenTypeText = reader.GetString(reader.GetOrdinal("TokenTypeText"))
                        }; 
                }
            } 
        }
    }
}
