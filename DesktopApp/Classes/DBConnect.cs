using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;

namespace DesktopApp.Classes 
{
    class DBConnect
    {
        MySqlConnection conn;
        string myConnectionString;
        static string host = "phpmyadmin.jverrijt.nl";
        static string database = "scannerapp";
        static string userDB = "jayv";
        static string password = "Woezel-2005!";
        static string ssltype = "None";
        static string dbport = "3306";
        static string dbpubkeyre = "true";
        static string strProvider = "server=" + host + ";Database=" + database + ";User ID=" + userDB + ";Password=" + password + ";SslMode=" + ssltype + ";Port=" + dbport + "AllowPublicKeyRetrieval=" + dbpubkeyre;
        // strProvider = "server=" + host + ";Database=" + database + ";User ID=" + userDB + ";Password=" + password;

        public bool Open()
        {
            try
            {
                strProvider = "server=" + host + ";Database=" + database + ";User ID=" + userDB + ";Password=" + password + ";SslMode=" +ssltype + ";Port=" + dbport + ";AllowPublicKeyRetrieval=" + dbpubkeyre;
               // strProvider = "server=" + host + ";Database=" + database + ";User ID=" + userDB + ";Password=" + password;
                conn = new MySqlConnection(strProvider);
                conn.Open();
                return true;
            }
            catch (Exception er)
            {
                Debug.WriteLine("Error DBConnect" + er);
            }
            return false;
        }

        public void Close()
        {
            conn.Close();
            conn.Dispose();
        }

        public DataSet ExecuteDataSet(string sql)
        {
            try
            {
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.Fill(ds, "result");
                return ds;
            }
            catch (Exception ex)
            {
               Debug.WriteLine("Error DBConnect"  + ex.Message);
            }
            return null;
        }

        public MySqlDataReader ExecuteReader(string sql)
        {
            try
            {
                MySqlDataReader reader;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
               Debug.WriteLine("Error DBConnect" + ex.Message);
            }
            return null;
        }

        public int ExecuteNonQuery(string sql)
        {
            try
            {
                int affected;
                MySqlTransaction mytransaction = conn.BeginTransaction();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                affected = cmd.ExecuteNonQuery();
                mytransaction.Commit();
                return affected;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error DBConnect" + ex.Message);
            }
            return -1;
        }
    }
}