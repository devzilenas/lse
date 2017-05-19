using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkShareEasyModel;
using System.Data.SqlClient;
using System.Transactions;

namespace LinkShareEasyADO
{
    public class ADOTokenUsage
    {
        private TokenUsage Insert(TokenUsage ntu)
        {
            using (var c = Connections.GetConnections.GetConnection())
            using (var cmd = c.CreateCommand())
            {
                c.Open();

                cmd.CommandText = "INSERT INTO TokenUsage (Token, UsedOn) VALUES (@1, @2); SELECT SCOPE_IDENTITY()";

                cmd.Parameters.AddWithValue("@1", ntu.Token);
                cmd.Parameters.AddWithValue("@2", ntu.UsedOn);

                var id = Convert.ToInt64(cmd.ExecuteScalar());
                return Find(id);
            }
        }

        private TokenUsage Find(long id)
        {
            using (var c = Connections.GetConnections.GetConnection())
            using (var cmd = c.CreateCommand())
            {
                c.Open();

                cmd.CommandText = "SELECT TOP 1 TokenUsageId, TokenId, Token, UsedOn FROM TokenUsage";
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        return new TokenUsage()
                        { 
                            TokenUsageId = reader.GetInt32(reader.GetOrdinal("TokenUsageId"))
                            , TokenId = reader.GetInt32(reader.GetOrdinal("TokenId"))
                            , Token = reader.GetString(reader.GetOrdinal("Token"))
                            , UsedOn = reader.GetDateTime(reader.GetOrdinal("UsedOn"))
                        };
                    }
                    else
                    {
                        throw new Exception(String.Format("Numeric token usage not found with id={0:d}", id));
                    }
                } 
            } 
        }
     }
}
