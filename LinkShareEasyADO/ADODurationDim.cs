using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkShareEasyModel;

namespace LinkShareEasyADO
{
    public class ADODurationDim
    {
        public DurationDim Find(String durationDimShortName)
        {
            using (var c = Connections.GetConnections.GetConnection())
            using (var cmd = c.CreateCommand())
            {
                c.Open();
                cmd.CommandText = "SELECT TOP 1 DurationDimId, DurationDimName, DurationDimSeconds, DurationDimShortName FROM DurationDim WHERE DurationDimShortName = @1";
                cmd.Parameters.AddWithValue("@1", durationDimShortName);

                using (var reader = cmd.ExecuteReader())
                {
                    return new DurationDim
                    {
                        DurationDimId = reader.GetInt32(reader.GetOrdinal("DurationDimId"))
                        , DurationDimName = reader.GetString(reader.GetOrdinal("DurationDimName"))
                        , DurationDimSeconds = reader.GetInt32(reader.GetOrdinal("DurationDimSeconds"))
                        , DurationDimShortName = reader.GetString(reader.GetOrdinal("DurationDimShortName"))
                    };
                }
            }
        }
    }
}
