using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace Connections
{
    public class GetConnections
    {
        public static String ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; 
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString());
        }
    }
}