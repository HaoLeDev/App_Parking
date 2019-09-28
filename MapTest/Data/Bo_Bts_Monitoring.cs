using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MapTest.Data
{
    public class Bo_Bts_Monitoring
    {
        private static SqlConnection conn = ConnectionSql.GetConnection();
        private static DataTable dt;
        private static SqlCommand cmd;
        private static SqlDataReader dr;
        private static int rowAffected = 0;

        public DataTable GetAll()
        {
            try
            {
                DataTable dt = new DataTable();
                ConnectionSql.OpenConnection(conn);
                cmd = new SqlCommand("Select * from BTS_MONITORING");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
                return dt;
            }
            catch(Exception)
            {
                return null;
            }
            finally
            {
                ConnectionSql.ReleaseAllResource(dr, cmd);
                ConnectionSql.CloseConnection(conn);
            }
        }
        public DataTable GetDTControllerLocation(string BTS_ID)
        {
            try
            {
                DataTable dt = new DataTable();
                ConnectionSql.OpenConnection(conn);
                cmd = new SqlCommand("SELECT * FROM CONTROLLER_LOCATION where BTS_ID = '" + BTS_ID + "'");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                {
                    dataAdapter.SelectCommand = cmd;
                    dataAdapter.Fill(dt);
                }
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                ConnectionSql.ReleaseAllResource(dr, cmd);
                ConnectionSql.CloseConnection(conn);
            }
        }
    }
}