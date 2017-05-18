using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkShareEasyModel;

namespace LinkShareEasyADO
{
    public class ADOTokenRequest
    {
        public TokenRequest Insert(TokenRequest tokenRequest)
        {
            using (var c = Connections.GetConnections.GetConnection())
            using (var cmd = c.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO TokenRequest(RequestedOn, LinkHref) VALUES (@1, @2); SELECT SCOPE_IDENTITY()";

                cmd.Parameters.AddWithValue("@1", tokenRequest.RequestedOn);
                cmd.Parameters.AddWithValue("@2", tokenRequest.LinkHref);

                var id = Convert.ToInt64(cmd.ExecuteScalar());
                return Find(id);
            }
        }

        private TokenRequest Find(long id)
        {
            using (var c = Connections.GetConnections.GetConnection())
            using (var cmd = c.CreateCommand())
            {
                cmd.CommandText = "SELECT TOP 1 TokenRequestId, RequestedOn, LinkHref, TokenId, LinkId FROM TokenRequests";
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        return new TokenRequest()
                        { 
                            TokenRequestId = reader.GetInt64(reader.GetOrdinal("TokenRequestId"))
                            , RequestedOn = reader.GetDateTime(reader.GetOrdinal("RequestedOn"))
                            , LinkHref = reader.GetString(reader.GetOrdinal("LinkHref"))
                            , TokenID = reader.GetInt64(reader.GetOrdinal("TokenId"))
                            , LinkId = reader.GetInt64(reader.GetOrdinal("LinkId"))
                        };
                    }
                    else
                    {
                        throw new Exception(String.Format("Token request not found with id={0:d}", id));
                    }
                } 
            } 
        }

    }
}
