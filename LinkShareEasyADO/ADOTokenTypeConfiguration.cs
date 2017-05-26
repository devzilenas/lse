using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkShareEasyModel;

namespace LinkShareEasyADO
{
    public class ADOTokenTypeConfiguration
    {
        public TokenTypeConfiguration Find(TokenType tokenType)
        {
            using (var c = Connections.GetConnections.GetConnection())
            using (var cmd = c.CreateCommand())
            {
                c.Open();

                cmd.CommandText = "SELECT TOP 1 TokenTypeConfigurationId, TokenTypeId, Enabled, DefaultValidForDurationDimId, DefaultValidForDuration FROM TokenTypeConfiguration WHERE TokenTypeId = @1";
                cmd.Parameters.AddWithValue("@1", tokenType.TokenTypeId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows && reader.Read())
                    {
                        return new TokenTypeConfiguration()
                        { 
                            TokenTypeConfigurationId = reader.GetInt32(reader.GetOrdinal("TokenTypeConfigurationId"))
                            , TokenTypeId = reader.GetInt32(reader.GetOrdinal("TokenTypeId"))
                            , Enabled = reader.GetBoolean(reader.GetOrdinal("Enabled"))
                            , DefaultValidForDurationDimId = reader.GetInt32(reader.GetOrdinal("DefaultValidForDurationDimId"))
                            , DefaultValidForDuration = reader.GetInt32(reader.GetOrdinal("DefaultValidForDuration"))
                        };
                    }
                    else
                    {
                        throw new Exception(String.Format("Token type configuration for token type id '{0}' not found.", tokenType.TokenTypeId));
                    }
                }
            }
        }
    }
}
