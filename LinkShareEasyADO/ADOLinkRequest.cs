using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkShareEasyModel;

namespace LinkShareEasyADO
{
    public class ADOLinkRequest
    {
        public LinkRequest Insert(LinkRequest linkRequest)
        {
           using (var c = Connections.GetConnections.GetConnection())
            using (var cmd = c.CreateCommand())
            {
                c.Open();

                cmd.CommandText = "INSERT INTO LinkRequests(RequestedOn, Token, Processed) VALUES (@1, @2, @3); SELECT SCOPE_IDENTITY()";

                cmd.Parameters.AddWithValue("@1", linkRequest.RequestedOn);
                cmd.Parameters.AddWithValue("@2", linkRequest.Token);
                cmd.Parameters.AddWithValue("@3", false);

                var id = Convert.ToInt64(cmd.ExecuteScalar());
                return Find(id);
            }
        }

        private LinkRequest Find(long id)
        {
            using (var c = Connections.GetConnections.GetConnection())
            using (var cmd = c.CreateCommand())
            {
                c.Open();

                cmd.CommandText = "SELECT TOP 1 LinkRequestId, RequestedOn, Token, Processed FROM LinkRequests";
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows && reader.Read())
                    {
                        return new LinkRequest()
                        { 
                            LinkRequestId = reader.GetInt32(reader.GetOrdinal("LinkRequestId"))
                            , RequestedOn = reader.GetDateTime(reader.GetOrdinal("RequestedOn"))
                            , Token = reader.GetString(reader.GetOrdinal("Token"))
                            , Processed = reader.GetBoolean(reader.GetOrdinal("Processed"))
                        };
                    }
                    else
                    {
                        throw new Exception(String.Format("Link request not found with id={0:d}", id));
                    }
                } 
            } 
        } 
    }
}
