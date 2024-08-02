using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DATA
{
    public class DbContext
    {
        public string ConnStr { get; set; }
        public SqlConnection Conn { get; set; }

        public DbContext()
        {
            ConnStr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            Conn = new SqlConnection(ConnStr);
            Open();
        }
        public void Open()
        {
            Conn.Open();
        }
        public void Close()
        {
            Conn.Close();
        }

        public DataTable Execute(string Sql)
        {
            SqlCommand Cmd = new SqlCommand(Sql, Conn);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            DataTable Dt = new DataTable();
            Da.Fill(Dt);
            Cmd.Dispose();
            return Dt;
        }
        public int ExecuteNonQuery(string Sql)
        {
            int ReCount = 0;
            SqlCommand Cmd = new SqlCommand(Sql, Conn);
            ReCount = Cmd.ExecuteNonQuery();
            Cmd.Dispose();
            return ReCount;
        }
        public int GetMaxId(string TableName, string PrimaryKeyName)
        {
            int MaxId = -1;
            string Sql = $"SELECT MAX( {PrimaryKeyName}) FROM {TableName} ";
            SqlCommand Cmd = new SqlCommand(Sql, Conn);
            MaxId = (int)Cmd.ExecuteScalar();
            Cmd.Dispose();
            return MaxId;
        }

        public object ExecuteScalar(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, Conn);
            object result = cmd.ExecuteScalar();
            cmd.Dispose();
            return result;
        }
    }
}