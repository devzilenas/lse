using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkShareEasyModel;

namespace LinkShareEasyADO
{
    public class ADONumericTokenUsage
    {
        private NumericTokenUsage Insert(NumericTokenUsage ntu)
        {
            using (var c = Connections.GetConnections.GetConnection())
            using (var cmd = c.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO NumericTokenUsage (LinkId, UsedOn, NumericTokenId) VALUES (@1, @2, @3); SELECT SCOPE_IDENTITY()";

                cmd.Parameters.AddWithValue("@1", ntu.LinkId );
                cmd.Parameters.AddWithValue("@2", ntu.UsedOn);
                cmd.Parameters.AddWithValue("@3", ntu.NumericTokenId);

                var id = Convert.ToInt64(cmd.ExecuteScalar());
                return Find(id);
            }
        }

        private NumericTokenUsage Find(long id)
        {
            using (var c = Connections.GetConnections.GetConnection())
            using (var cmd = c.CreateCommand())
            {
                cmd.CommandText = "SELECT TOP 1 NumericTokenUsageId, LinkId, UsedOn, NumericTokenId FROM NumericTokenUsage";
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        return new NumericTokenUsage()
                        { 
                            NumericTokenUsageId = reader.GetInt64(reader.GetOrdinal("NumericTokenUsageId"))
                            , LinkId = reader.GetInt64(reader.GetOrdinal("LinkId"))
                            , UsedOn = reader.GetDateTime(reader.GetOrdinal("UsedOn"))
                            , NumericTokenId = reader.GetInt64(reader.GetOrdinal("NumericTokenId"))
                        };
                    }
                    else
                    {
                        throw new Exception(String.Format("Numeric token usage not found with id={0:d}", id));
                    }
                } 
            } 
        }

        /// <summary>
        /// Makes one token as used.
        /// </summary>
        /// <param name="nt"></param>
        public NumericTokenUsage MakeUsed(NumericToken nt, TokenRequest tokenRequest)
        {
            NumericTokenUsage ntu = NumericTokenUsage(nt, tokenRequest);
            return Insert(ntu);
        }

        private NumericTokenUsage NumericTokenUsage(NumericToken nt, TokenRequest tokenRequest)
        {
            return new NumericTokenUsage()
            {
                NumericTokenId = nt.NumericTokenID
               ,
                UsedOn = DateTime.Now
               ,
                LinkId = tokenRequest.LinkId
            };
        }
    }
}
