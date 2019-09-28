using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;

namespace BTSMonitoring.Data
{
    public class Connection
    {
        public static OracleConnection GetConnection()
        {
            string connStr = "Data Source = (DESCRIPTION ="
              + "(ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP) (HOST = " + ConfigurationManager.AppSettings["Database"] + ") (PORT = 1521)))"
              + "(CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = IMS )));"
              + "User ID = " + ConfigurationManager.AppSettings["DBName"] + ";Password = " + ConfigurationManager.AppSettings["DBPass"] + ";";
            OracleConnection con = new OracleConnection(connStr);
            return con;
        }
        public static void OpenConnection(OracleConnection con)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public static void CloseConnection(OracleConnection con)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        public static void DisposeCommand(OracleCommand cmd)
        {
            if (cmd != null)
            {
                cmd.Dispose();
            }

        }
        public static void CloseDataReader(OracleDataReader dr)
        {
            if (dr != null)
            {
                dr.Close();
            }
        }
        public static void ReleaseAllResource(OracleDataReader dr, OracleCommand cmd)
        {
            if (dr != null)
            {
                dr.Dispose();
            }
            if (cmd != null)
            {
                cmd.Dispose();
            }
        }
    }
}