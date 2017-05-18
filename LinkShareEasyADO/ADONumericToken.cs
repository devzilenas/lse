using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkShareEasyModel;
using Connections;
using System.Data.SqlClient;

namespace LinkShareEasyADO
{
    public class ADONumericToken
    {
        public long Insert(IToken numericToken)
        { 
            using (var c = Connections.GetConnections.GetConnection())
            using (var cmd = c.CreateCommand())
            using (var t = c.BeginTransaction(System.Data.IsolationLevel.Serializable))
            { 
                c.Open();
                cmd.CommandText = "INSERT INTO NumericTokens (NumericToken, Used) VALUES (@1, @2); SELECT SCOPE_IDENTITY()";

                cmd.Parameters.AddWithValue("@1", numericToken.TokenText);
                cmd.Parameters.AddWithValue("@2", 1);

                var id = Convert.ToInt64(cmd.ExecuteScalar());
                return id; 
            }
        }

        /// <summary>
        /// Tells whether numeric token in already used for some link.
        /// </summary>
        /// <param name="numericToken"></param>
        /// <returns></returns>
        public bool IsAvailable(NumericToken numericToken)
        {
            using (var c = Connections.GetConnections.GetConnection())
            using (var cmd = c.CreateCommand())
            {
                cmd.CommandText = "SELECT TOP 1 NumericTokenID FROM NumericTokens WHERE Used = @1";
                cmd.Parameters.AddWithValue("@1", false);

                using (var reader = cmd.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
            throw new Exception("Numeric token find operation failed.");
        }

        /// <summary>
        /// Returns available numeric token.
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        public NumericToken GetAvailable(int limit)
        {
            using (var c = Connections.GetConnections.GetConnection())
            using (var cmd = c.CreateCommand())
            {
                cmd.CommandText = "SELECT TOP @2 NumericTokenID, NumericToken, Used WHERE Used = @1";
                cmd.Parameters.AddWithValue("@1",false);
                cmd.Parameters.AddWithValue("@2", limit);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return new NumericToken()
                        { 
                            NumericTokenID = reader.GetInt64(reader.GetOrdinal("NumericTokenID"))
                            , NumericTokenText = reader.GetInt32(reader.GetOrdinal("NumericToken"))
                            , Used = reader.GetBoolean(reader.GetOrdinal("Used"))
                        };
                    }
                    else
                    {
                        throw new Exception("Available numeric tokens not found"); //TODO account for this situation
                    }
                }
            } 
        }

    }
}
