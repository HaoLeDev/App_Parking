using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BTSMonitoring.Data
{
    public class Bo_BtsMonitoring
    {
        public OracleConnection conn = Connection.GetConnection();
        private OracleCommand cmd;
        private OracleDataReader dr;
        private int rowAffected = 0;
        public DataTable GetDTMonitoring()
        {
            try
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
        public DataTable GetDTControllers()
        {
            try
            {
                DataTable dt = new DataTable();
                Connection.OpenConnection(conn);
                cmd = new OracleCommand("SELECT NAME, LAT, LNG, TEMP, HUMI FROM BTS_CONTROLLERS");
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
        public DataTable GetDTControllerLocation(string BTS_ID)
        {
            try
            {
                DataTable dt = new DataTable();
                Connection.OpenConnection(conn);
                cmd = new OracleCommand("SELECT * FROM CONTROLLER_LOCATION where BTS_ID = '" + BTS_ID + "'");
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

        public DataTable GetDTAll()
        {
            try
            {
                DataTable dt = new DataTable();
                Connection.OpenConnection(conn);
                cmd = new OracleCommand("SELECT * FROM CONTROLLER_LOCATION");
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
        public int AddPointBTS2DB(string LAT, string LNG, string NAME)
        {
            rowAffected = 0;
            try
            {
                Connection.OpenConnection(conn);
                cmd = new OracleCommand();
                cmd.CommandText = @"Insert into BTS_MONITORING(ID, NAME, LAT, LNG, IMAGE)
                    values (:ID,:NAME,:LAT,:LNG, :IMAGE)";
                cmd.Connection = conn;
                cmd.Parameters.Add(":ID", (int)(numPoint() + 1));
                cmd.Parameters.Add(":NAME", NAME);
                cmd.Parameters.Add(":LAT", LAT);
                cmd.Parameters.Add(":LNG", LNG);
                cmd.Parameters.Add(":IMAGE", "");
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
        public int numPoint()//chỉ được phép sử dụng ở AddPointBTS2DB vì kết thúc phương thức chưa giải phóng tài nguyên
        {
            rowAffected = 0;
            try
            {
                Connection.OpenConnection(conn);
                cmd = new OracleCommand();
                cmd.CommandText = @"select count(*) from BTS_MONITORING";
                cmd.Connection = conn;
                rowAffected = Int32.Parse(cmd.ExecuteScalar().ToString().Trim());
                return rowAffected;
            }
            catch
            {
                return 0;
            }
        }
        
    }
}