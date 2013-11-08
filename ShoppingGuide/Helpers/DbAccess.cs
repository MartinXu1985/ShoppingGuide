using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace ShoppingGuide.Helpers
{
    public class DbAccess
    {
        string connectionString = ConfigurationManager.
                ConnectionStrings["ApplicationServices"].ConnectionString;
        SqlConnection sqlConn = null;

        public SqlConnection getConnection()
        {
            if (sqlConn == null)
            {
                sqlConn = new SqlConnection(connectionString);
            }

            return sqlConn;
        }
    }
}