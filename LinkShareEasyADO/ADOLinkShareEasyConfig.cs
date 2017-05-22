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
        public LinkShareEasyConfig Find()
        {
            using (var c = Connections.GetConnections.GetConnection())
            using (var cmd = c.CreateCommand())
            {
                c.Open();
                cmd.CommandText = "SELECT TOP 1 TransferAfterDuration*DurationDimSeconds AS TransferAfterSeconds, DefaultDurationDimId, DefaultDuration FROM LinkShareEasyConfig JOIN DurationDim ON DurationDim.DurationDimId = LinkShareEasyConfig.TransferAfterDurationDimId";

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows && reader.Read())
                    {
                        LinkShareEasyConfig lsec = new LinkShareEasyConfig()
                        {
                            TransferAfterDuration = reader.GetInt32(reader.GetOrdinal("TransferAfterSeconds"))
                            , DefaultDurationDimId = reader.GetInt32(reader.GetOrdinal("DefaultDurationDimId"))
                            , DefaultDuration = reader.GetInt32(reader.GetOrdinal("DefaultDuration"))
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
