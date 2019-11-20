using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist1
{
    class DXL
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlConnection cn;
        DataTable dt = new DataTable();

        public DXL()  /*  باني افتراضي لاجل بناء اتصال */
        {
          cn = new SqlConnection(@"server=DESKTOP-8TO5IGN\SQLEXPRESS;database=Dentist ;integrated security=true");
        }

        public void open()
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
        }

        public void close()
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
        //تابع لقراءة البيانات من قاعدة البيانات
        public DataTable Reader(string sp, SqlParameter[] p)
        {
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sp;
            cmd.Connection = cn;
            if (p != null)
            {
                cmd.Parameters.AddRange(p);
            }
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;


        }
        //Remove ,Update ,Add
        public void RUA(string sp, SqlParameter[] p)
        {
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sp;
            cmd.Connection = cn;
            if (p != null)
            {
                cmd.Parameters.AddRange(p);
            }
            cmd.ExecuteNonQuery();

        }
    }
}
