using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinkShareEasyModel;
using System.Threading.Tasks;

namespace LinkShareEasyADO
{
    public class ADOBanner
    {
        public Banner Find()
        {
            using (var c = Connections.GetConnections.GetConnection())
            using (var cmd = c.CreateCommand())
            {
                c.Open();
                cmd.CommandText = "SELECT TOP 1 BannerId, AlternateTextField, ImageUrlField, NavigateUrlField FROM Banners";

                using (var reader = cmd.ExecuteReader())
                {
                    return new Banner()
                    {
                        BannerId = reader.GetInt32(reader.GetOrdinal("BannerId"))
                        , AlternateTextField = reader.GetString(reader.GetOrdinal("AlternateTextField"))
                        , ImageUrlField = reader.GetString(reader.GetOrdinal("ImageUrlField"))
                        , NavigateUrlField = reader.GetString(reader.GetOrdinal("NavigateUrlField"))
                    };
                }
            }
        }
    }
}
