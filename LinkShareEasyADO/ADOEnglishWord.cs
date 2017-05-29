using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkShareEasyModel;


namespace LinkShareEasyADO
{
    public class ADOEnglishWord
    { 
        public bool IsAvailable(IToken token)
        {
            EnglishWordToken ewt = (EnglishWordToken) Find(token.TokenText);
            return ewt.Used;
        }

        public IToken Find(String tokenText)
        {
            using (var c = Connections.GetConnections.GetConnection())
            using (var cmd = c.CreateCommand())
            {
                c.Open();
                cmd.CommandText =
                @"SELECT 
                  TOP       1
                            EnglishWordTokenId, EnglishWordTokenText, Used
                  FROM      EnglishWordTokens
                  WHERE     EnglishWordTokenText = @1 ";
                cmd.Parameters.AddWithValue("@1", tokenText);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows && reader.Read())
                    {
                        return new EnglishWordToken()
                        {
                            EnglishWordTokenId = reader.GetInt32(reader.GetOrdinal("EnglishWordTokenId"))
                            ,
                            EnglishWordTokenText = reader.GetString(reader.GetOrdinal("EnglishWordTokenText"))
                            ,
                            Used = reader.GetBoolean(reader.GetOrdinal("Used"))
                        };
                    }
                    else
                    {
                        throw new Exception(String.Format("Token '{0}' not found.", tokenText));
                    }
                }
            }
        }

        public IToken SetUsed(String tokenText, bool used)
        {
            using (var c = Connections.GetConnections.GetConnection())
            using (var cmd = c.CreateCommand())
            {
                c.Open();
                cmd.CommandText = "UPDATE EnglishWordTokens SET Used = @1 WHERE EnglishWordTokenText = @2";

                cmd.Parameters.AddWithValue("@1", used);
                cmd.Parameters.AddWithValue("@2", tokenText);

                cmd.ExecuteNonQuery();
                return Find(tokenText);
            }
        }

        /// <summary>
        /// Gets unused token.
        /// </summary>
        /// <returns></returns>
        public IToken GetAvailable()
        {
            using (var c = Connections.GetConnections.GetConnection())
            using (var cmd = c.CreateCommand())
            {
                c.Open();

                cmd.CommandText =
                @"SELECT 
                  TOP       1
                            EnglishWordTokenId, EnglishWordTokenText, Used
                  FROM      EnglishWordTokens
                  WHERE     Used = @1
                  ORDER BY
                            NEWID()"; //Random
                cmd.Parameters.AddWithValue("@1", false);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows && reader.Read())
                    {
                        return new EnglishWordToken()
                        {
                            EnglishWordTokenId = reader.GetInt32(reader.GetOrdinal("EnglishWordTokenId"))
                            , EnglishWordTokenText = reader.GetString(reader.GetOrdinal("EnglishWordTokenText"))
                            , Used = reader.GetBoolean(reader.GetOrdinal("Used"))
                        }; 
                    }
                    else
                    {
                        throw new Exception("Available english word tokens not found.");
                    }
                } 
            }
        }
    }
}
