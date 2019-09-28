using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BTSMonitoring.Data
{
    public class Bo_Accounts
    {
        public OracleConnection conn = Connection.GetConnection();
        private OracleCommand cmd;
        private OracleDataReader dr;
        private int rowAffected = 0;

        public int CheckLogin(string userName, string passWord)
        {
            try
            {
                Connection.OpenConnection(conn);
                cmd = new OracleCommand("SELECT COUNT(*) FROM ACCOUNT WHERE USER_NAME = :USER_NAME AND PASSWORD = :PASSWORD");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.Parameters.Add(":USER_NAME", userName);
                cmd.Parameters.Add(":PASSWORD", passWord);
                object obj = cmd.ExecuteScalar();
                if(obj == null || int.Parse(obj.ToString().Trim()) < 1)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(obj.ToString().Trim());
                }
            }
            catch(Exception ex)
            {
                throw;
                return 0;
            }
        }
        public string GetBTSbyAccount(string username)
        {
            try
            {
                Connection.OpenConnection(conn);
                cmd = new OracleCommand("SELECT LIST_BTS FROM ACCOUNT WHERE USER_NAME = :USER_NAME");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.Parameters.Add(":USER_NAME", username);
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
                Connection.ReleaseAllResource(dr, cmd);
                Connection.CloseConnection(conn);
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
                if(lst.Substring(lst.Length - 1) == ",")
                {
                    lst = lst.Remove(lst.Length - 1);
                }
                DataTable dt = new DataTable();
                Connection.OpenConnection(conn);
                cmd = new OracleCommand("SELECT * FROM BTS_MONITORING WHERE ID IN (" + lst + ")");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                using (OracleDataAdapter dataAdapter = new OracleDataAdapter())
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
                Connection.ReleaseAllResource(dr, cmd);
                Connection.CloseConnection(conn);
            }
        }
        public DataTable GetAll()
        {
            DataTable dt = new DataTable();
            Connection.OpenConnection(conn);
            cmd = new OracleCommand("SELECT * FROM BTS_MONITORING");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            using (OracleDataAdapter dataAdapter = new OracleDataAdapter())
            {
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(dt);
            }
            return dt;
        }
        public int AddAccount(string userName, string passWord)
        {
            rowAffected = 0;
            try
            {
                Connection.OpenConnection(conn);
                cmd = new OracleCommand();
                cmd.CommandText = @"Insert into BTS_CONTROLLERS(ID, USER_NAME, PASSWORD, STATUS)
                    values (:ID,:USER_NAME,:PASSWORD,:STATUS)";
                cmd.Connection = conn;
                cmd.Parameters.Add(":ID", Common.DateTimeToLong(DateTime.Now).ToString().Trim());
                cmd.Parameters.Add(":USER_NAME", userName);
                cmd.Parameters.Add(":PASSWORD", Common.MD5Hash(passWord));
                cmd.Parameters.Add(":STATUS", "1");
                rowAffected = cmd.ExecuteNonQuery();
                return rowAffected;
            }
            catch
            {
                return 0;
            }
            finally
            {
                Connection.ReleaseAllResource(dr, cmd);
                Connection.CloseConnection(conn);
            }
        }
    }
}