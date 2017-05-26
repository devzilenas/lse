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
        public DurationDim Find(int id)
        {
            using (var c = Connections.GetConnections.GetConnection())
            using (var cmd = c.CreateCommand())
            {
                c.Open();
                cmd.CommandText = "SELECT TOP 1 DurationDimId, DurationDimName, DurationDimSeconds, DurationDimShortName FROM DurationDim WHERE DurationDimId = @1";

                cmd.Parameters.AddWithValue("@1", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows && reader.Read())
                    { 
                        return new DurationDim() 
                        {
                            DurationDimId = reader.GetInt32(reader.GetOrdinal("DurationDimId"))
                            , DurationDimName = reader.GetString(reader.GetOrdinal("DurationDimName"))
                            , DurationDimSeconds = reader.GetInt32(reader.GetOrdinal("DurationDimSeconds"))
                            , DurationDimShortName = reader.GetString(reader.GetOrdinal("DurationDimShortName"))
                        };
                    }
                    else
                    {
                        throw new Exception(String.Format("Duration not found for id '{0}'.", id));
                    }
                } 
            }
        }

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

        public int GetSeconds(int id, int duration)
        {
            DurationDim dd = Find(id);
            return dd.DurationDimSeconds * duration;
        }
    }
}
