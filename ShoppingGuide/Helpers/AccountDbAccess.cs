using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingGuide.Models;
using System.Data.SqlClient;

namespace ShoppingGuide.Helpers
{
    public class AccountDbAccess
    {
        DbAccess db = new DbAccess();
        string tableName = "ACCOUNT";

        AccountDbAccess()
        {
            // Upon construction, reset dummy data.  Comment out to disable
            // resetting
            resetDummyData();
        }

        private void resetDummyData()
        {
            // TODO
        }

        public Account findAccount(string username, string password)
        {
            string searchString = "WHERE username='" + username + "' AND " +
                                  "password='" + password + "'";

            SqlCommand SqlCommand = new SqlCommand();
            SqlDataReader dr = null;
            Account tempAcc = null;

            try
            {
                // Open connection to the DB
                db.getConnection().Open();

                // Setup the command
                SqlCommand.CommandText = "select * from" + tableName;
                SqlCommand.Connection = db.getConnection();
                dr = SqlCommand.ExecuteReader();

                while (dr.Read())
                {
                    tempAcc = new Account();
                    tempAcc.Username = (string)dr["Username"];
                    tempAcc.Password = (string)dr["Password"];
                    break;
                }
            }
            catch (Exception ex)
            {
                // Do nothing for now
            }
            finally
            {
                if (dr != null) dr.Close();
                db.getConnection().Close();
            }

            return tempAcc;
        }
    }
}