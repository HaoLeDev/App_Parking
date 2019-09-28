using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MapTest.Data
{
    public class Bo_Bts_Account
    {
        private static SqlConnection conn = ConnectionSql.GetConnection();
        private static DataTable dt;
        private static SqlCommand cmd;
        private static SqlDataReader dr;
        private static int rowAffected = 0;
        public int CheckLogin(string userName, string passWord)
        {
            try
            {
                ConnectionSql.OpenConnection(conn);
                cmd = new SqlCommand("SELECT COUNT(*) FROM ACCOUNT WHERE USER_NAME = @USER_NAME AND PASSWORD = @PASSWORD");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@USER_NAME", userName);
                cmd.Parameters.AddWithValue("@PASSWORD", passWord);
                object obj = cmd.ExecuteScalar();
                if (obj == null || int.Parse(obj.ToString().Trim()) < 1)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(obj.ToString().Trim());
                }
            }
            catch (Exception ex)
            {
                return 0;
                throw;
                
            }  
        }
        public DataTable GetBTSDataByAccount(string username)
        {
            try
            {
                string lst = GetBTSbyAccount(username).Trim();
                if (String.IsNullOrWhiteSpace(lst))
                {
                    return null;
                }
                if (lst.Substring(lst.Length - 1) == ",")
                {
                    lst = lst.Remove(lst.Length - 1);
                }
                DataTable dt = new DataTable();
                ConnectionSql.OpenConnection(conn);
                cmd = new SqlCommand("SELECT * FROM BTS_MONITORING WHERE ID IN (" + lst + ")");
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
        public DataTable GetAll()
        {
            DataTable dt = new DataTable();
            ConnectionSql.OpenConnection(conn);
            cmd = new SqlCommand("SELECT * FROM BTS_MONITORING");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(dt);
            }
            return dt;
        }
        public string GetBTSbyAccount(string username)
        {
            try
            {
                ConnectionSql.OpenConnection(conn);
                cmd = new SqlCommand("SELECT LIST_BTS FROM ACCOUNT WHERE USER_NAME = @USER_NAME");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@USER_NAME", username);
                object obj = cmd.ExecuteScalar();
                if (obj == null || String.IsNullOrWhiteSpace(obj.ToString())) return null;
                else return obj.ToString().Trim();
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