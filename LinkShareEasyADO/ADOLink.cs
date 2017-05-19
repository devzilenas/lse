using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkShareEasyModel;

namespace LinkShareEasyADO
{
    public class ADOLink
    {
        public Link Insert(Link link)
        {
            using (var c = Connections.GetConnections.GetConnection())
            using (var cmd = c.CreateCommand())
            {
                c.Open();

                cmd.CommandText = "INSERT INTO Links(LinkHref, TokenId) VALUES(@1, @2); SELECT SCOPE_IDENTITY()";
                cmd.Parameters.AddWithValue("@1", link.LinkHref);
                cmd.Parameters.AddWithValue("@2", link.TokenId);

                return new Link()
                { 
                    LinkId = Convert.ToInt32(cmd.ExecuteScalar())
                    , LinkHref = link.LinkHref
                    , TokenId = link.TokenId
                };
            }
        }
    }
}
