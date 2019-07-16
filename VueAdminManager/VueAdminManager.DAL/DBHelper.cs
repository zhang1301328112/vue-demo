using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace VueAdminManager.DAL
{
    public class DBHelper
    {
        public static string connStr = "server=.;uid=sa;pwd=123456;database=MYAdminManager;";
        public static DataTable GetTable(string sql)
        {
            SqlConnection conn = new SqlConnection(connStr);
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static bool InsretOrDeleteOrUpdate(string sql)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            return cmd.ExecuteNonQuery() > 0;
        }
        public static object GetValue(string sql)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            return cmd.ExecuteScalar();
        }
    }
}
