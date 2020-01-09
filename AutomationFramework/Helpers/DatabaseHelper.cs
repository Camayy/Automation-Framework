using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AutomationFramework.Helpers
{
    public static class DatabaseHelper
    {
        //open connection
        public static SqlConnection DBConnect(this SqlConnection con, string dbName)
        {
            try
            {
                con = new SqlConnection(dbName);
                con.Open();
                return con;
            }
            catch(Exception e)
            {
                Logging.Write("Database connection error: " + e.Message);
            }
            return null;
        }
        //closing connection
        public static void DBClose(this SqlConnection con)
        {
            try
            {
                con.Close();
            }
            catch(Exception e)
            {
                Logging.Write("Database close error: " + e.Message);
            }
        }

        public static DataTable ExecuteQuery(this SqlConnection con, string query)
        {
            DataSet data = new DataSet();
            try
            {
                //Check connection is open
                if (con == null)
                    con.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = new SqlCommand(query, con);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;

                dataAdapter.Fill(data, "table");
                con.Close();
                return data.Tables["table"];
            }
            catch (Exception e)
            {
                Logging.Write("ERROR: QuerySelect DB: " + e.Message);
            }
            finally
            {
                con.Close();
                data = null;
            }
            return null;
        }
        //select record
        //edit record
        //delete record
    }
}
