using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkShareEasyModel;

namespace LinkShareEasyADO
{
    public class ADOLinkShareEasyConfig
    {
        /// <summary>
        /// Returns a config.
        /// </summary>
        /// <returns></returns>
        public LinkShareEasyConfig Find()
        {
            using (var c = Connections.GetConnections.GetConnection())
            using (var cmd = c.CreateCommand())
            {
                c.Open();
                cmd.CommandText = "SELECT TOP 1 TransferAfterDuration, TransferAfterDurationDimId, TransferAfterDuration*d1.DurationDimSeconds AS TransferAfterSeconds, DefaultDurationDimId, DefaultDuration, DefaultDuration*d2.DurationDimSeconds AS DefaultDurationSeconds FROM LinkShareEasyConfig JOIN DurationDim AS d1 ON d1.DurationDimId = LinkShareEasyConfig.TransferAfterDurationDimId JOIN DurationDim AS d2 ON d2.DurationDimId = LinkShareEasyConfig.DefaultDurationDimId";

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows && reader.Read())
                    {
                        LinkShareEasyConfig lsec = new LinkShareEasyConfig()
                        {
                            TransferAfterDuration = reader.GetInt32(reader.GetOrdinal("TransferAfterSeconds"))
                            , TransferAfterDurationDimId = reader.GetInt32(reader.GetOrdinal("TransferAfterDurationDimId"))
                            , TransferAfterSeconds = reader.GetInt32(reader.GetOrdinal("TransferAfterSeconds"))
                            , DefaultDurationDimId = reader.GetInt32(reader.GetOrdinal("DefaultDurationDimId"))
                            , DefaultDuration = reader.GetInt32(reader.GetOrdinal("DefaultDuration"))
                            , DefaultDurationSeconds = reader.GetInt32(reader.GetOrdinal("DefaultDurationSeconds"))
                        };

                        return lsec;
                    }
                    else
                    {
                        throw new Exception("Not found LinkShareEasyConfig.");
                    }
                }
            }
        }
    }
}
