using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MapTest.Data
{
    public class ConnectionSql
    {    
        public static SqlConnection GetConnection()
        {
            string server = ConfigurationManager.AppSettings["serverName"];
            string database = ConfigurationManager.AppSettings["databaseName"];
            string uid = ConfigurationManager.AppSettings["uidName"];
            string pwd = ConfigurationManager.AppSettings["pwdName"];
            string ConStr = @"server =" + server + "; database=" + database + "; integrated security= false; uid=" + uid + "; pwd=" + pwd + ";";
            SqlConnection con = new SqlConnection(ConStr);
            return con;
        }
        //public static DataTable GetDataTable(string sql)
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        OpenConnection(conn);
        //        SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
        //        return dt;
        //    }
        //    catch(Exception ex)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        ReleaseAllResource(dr, cmd);
        //        CloseConnection(conn);
        //    }
        //}
        public static void OpenConnection(SqlConnection con)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
        }
        public static void CloseConnection(SqlConnection con)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }
        public static void ReleaseAllResource(SqlDataReader dr, SqlCommand cmd)
        {
            if (dr != null)
            {
                dr.Dispose();
                dr = null;
            }
            if(cmd != null)
            {
                cmd.Dispose();
                cmd = null;
            }
        }
    }
}