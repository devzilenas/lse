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
        public Token FindValid(String token)
        { 
            using (var c = Connections.GetConnections.GetConnection())
            using (var cmd = c.CreateCommand())
            {
                c.Open();
                cmd.CommandText = "SELECT TOP 1 TokenId, TokenText, TokenTypeId, ValidForDurationDimId, ValidForDuration, IsExpired, ValidForDuration*DurationDim.DurationDimSeconds AS [ValidForDurationSeconds] JOIN DurationDim ON DurationDim.DurationDimId = ValidForDurationDimId FROM Tokens WHERE IsExpired = @1";
                cmd.Parameters.AddWithValue("@1", false);

                using (var reader = cmd.ExecuteReader())
                {
                    return new Token()
                    { 
                       TokenId = reader.GetInt32(reader.GetOrdinal("TokenId")) 
                       , TokenText = reader.GetString(reader.GetOrdinal("TokenText"))
                       , TokenTypeId = reader.GetInt32(reader.GetOrdinal("TokenTypeId"))
                       , ValidForDurationDimId = reader.GetInt32(reader.GetOrdinal("ValidForDurationDimId")) 
                       , ValidForDuration = reader.GetInt32(reader.GetOrdinal("ValidForDuration"))
                       , IsExpired = reader.GetBoolean(reader.GetOrdinal("IsExpired"))
                       , ValidForDurationSeconds = reader.GetInt32(reader.GetOrdinal("ValidForDurationSeconds"))
                    };
                }
            }
        }

        public Token Find(int id)
        {
            using (var c = Connections.GetConnections.GetConnection())
            using (var cmd = c.CreateCommand())
            {
                c.Open();
                cmd.CommandText = "SELECT TokenId, TokenText, TokenTypeId, ValidForDurationDimId, ValidForDuration, IsExpired, ValidForDuration*DurationDim.DurationDimSeconds AS [ValidForDurationSeconds] JOIN DurationDim ON DurationDim.DurationDimId = ValidForDurationDimId FROM Tokens WHERE TokenId = @1";
                cmd.Parameters.AddWithValue("@1", id);

                using (var reader = cmd.ExecuteReader())
                {
                    return new Token()
                    { 
                       TokenId = reader.GetInt32(reader.GetOrdinal("TokenId")) 
                       , TokenText = reader.GetString(reader.GetOrdinal("TokenText"))
                       , TokenTypeId = reader.GetInt32(reader.GetOrdinal("TokenTypeId"))
                       , ValidForDurationDimId = reader.GetInt32(reader.GetOrdinal("ValidForDurationDimId")) 
                       , ValidForDuration = reader.GetInt32(reader.GetOrdinal("ValidForDuration"))
                       , IsExpired = reader.GetBoolean(reader.GetOrdinal("IsExpired"))
                       , ValidForDurationSeconds = reader.GetInt32(reader.GetOrdinal("ValidForDurationSeconds"))
                    };
                }
            }

        }

        public Token Insert(Token token)
        {
            using (var c = Connections.GetConnections.GetConnection())
            using (var cmd = c.CreateCommand())
            {
                c.Open();

                cmd.CommandText = "INSERT INTO Tokens (TokenText, TokenTypeId, ValidForDurationDimId, ValidForDuration, IsExpired) VALUES (@1, @2, @3, @4, @5); SELECT SCOPE_IDENTITY()";
                cmd.Parameters.AddWithValue("@1", token.TokenText);
                cmd.Parameters.AddWithValue("@2", token.TokenTypeId);
                cmd.Parameters.AddWithValue("@3", token.ValidForDurationDimId);
                cmd.Parameters.AddWithValue("@4", token.ValidForDuration);
                cmd.Parameters.AddWithValue("@5", token.IsExpired);

                return Find(Convert.ToInt32(cmd.ExecuteScalar()));
            }
        }

        public void Expire(Token token)
        {
            using (var c = Connections.GetConnections.GetConnection())
            using (var cmd = c.CreateCommand())
            {
                c.Open();

                cmd.CommandText = "UPDATE Tokens SET IsExpired = @2 WHERE TokenId = @1";
                cmd.Parameters.AddWithValue("@1", token.TokenId);
                cmd.Parameters.AddWithValue("@2", true);
                cmd.ExecuteNonQuery();
            }
        }
    }

}
