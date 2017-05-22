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
                c.Open();

                cmd.CommandText = "INSERT INTO TokenRequests(RequestedOn, LinkHref, TokenId, LinkId, TokenTypeId) VALUES (@1, @2, @3, @4, @5); SELECT SCOPE_IDENTITY()";

                cmd.Parameters.AddWithValue("@1", tokenRequest.RequestedOn);
                cmd.Parameters.AddWithValue("@2", tokenRequest.LinkHref);
                cmd.Parameters.AddWithValue("@3", tokenRequest.TokenId);
                cmd.Parameters.AddWithValue("@4", tokenRequest.LinkId);
                cmd.Parameters.AddWithValue("@5", tokenRequest.TokenTypeId);

                var id = Convert.ToInt64(cmd.ExecuteScalar());
                return Find(id);
            }
        }

        public TokenRequest FindFor(Token token)
        {
            int tokenId = token.TokenId;
            using (var c = Connections.GetConnections.GetConnection())
            using (var cmd = c.CreateCommand())
            {
                c.Open();

                cmd.CommandText = "SELECT TOP 1 TokenRequestId, RequestedOn, LinkHref, TokenId, LinkId, TokenTypeId FROM TokenRequests WHERE TokenId = @1";
                cmd.Parameters.AddWithValue("@1", tokenId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows && reader.Read())
                    {
                        return new TokenRequest()
                        { 
                            TokenRequestId = reader.GetInt32(reader.GetOrdinal("TokenRequestId"))
                            , RequestedOn = reader.GetDateTime(reader.GetOrdinal("RequestedOn"))
                            , LinkHref = reader.GetString(reader.GetOrdinal("LinkHref"))
                            , TokenId = reader.GetInt32(reader.GetOrdinal("TokenId"))
                            , LinkId = reader.GetInt32(reader.GetOrdinal("LinkId"))
                            , TokenTypeId = reader.GetInt32(reader.GetOrdinal("TokenTypeId"))
                        };
                    }
                    else
                    {
                        throw new Exception(String.Format("Token request not found with id={0:d}", tokenId));
                    }
                } 
            } 
        }

        private TokenRequest Find(long id)
        {
            using (var c = Connections.GetConnections.GetConnection())
            using (var cmd = c.CreateCommand())
            {
                c.Open();

                cmd.CommandText = "SELECT TOP 1 TokenRequestId, RequestedOn, LinkHref, TokenId, LinkId, TokenTypeId FROM TokenRequests";
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows && reader.Read())
                    {
                        return new TokenRequest()
                        { 
                            TokenRequestId = reader.GetInt32(reader.GetOrdinal("TokenRequestId"))
                            , RequestedOn = reader.GetDateTime(reader.GetOrdinal("RequestedOn"))
                            , LinkHref = reader.GetString(reader.GetOrdinal("LinkHref"))
                            , TokenId = reader.GetInt32(reader.GetOrdinal("TokenId"))
                            , LinkId = reader.GetInt32(reader.GetOrdinal("LinkId"))
                            , TokenTypeId = reader.GetInt32(reader.GetOrdinal("TokenTypeId"))
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
