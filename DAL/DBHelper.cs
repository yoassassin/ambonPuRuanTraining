using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DBHelper
    {
        public DataTable GetListBySQL(string SQL)
        {
            string strConn = "server=.;database=Test;trusted_connection=true;";
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed) { conn.Open(); }

            SqlDataAdapter da = new SqlDataAdapter(SQL,conn);

            DataTable dt = new DataTable();
            conn.Close();
            try
            { da.Fill(dt); }
            catch (Exception)
            { throw; }

            return dt;
        }

        public bool GetBoolBySQL(string SQL)
        {
            string strConn = "server=.;database=Test;trusted_connection=true;";
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed) { conn.Open(); }

            SqlCommand cd = new SqlCommand(SQL,conn);
            int i = cd.ExecuteNonQuery();
            conn.Close();

            return i > 0 ? true : false;
        }

        public object GetObjectBySQL(string SQL)
        {
            string strConn = "server=.;database=Test;trusted_connection=true;";
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed) { conn.Open(); }

            SqlCommand cd = new SqlCommand(SQL, conn);
            object o = cd.ExecuteScalar();
            conn.Close();

            return o;
        }

        public DataSet GetDataSetBySQL(string SQL)
        {
            string strConn = "server=.;database=Test;trusted_connection=true;";
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed) { conn.Open(); }

            SqlDataAdapter da = new SqlDataAdapter(SQL, conn);

            DataSet ds = new DataSet();
            conn.Close();
            try
            { da.Fill(ds); }
            catch (Exception)
            { throw; }

            return ds;
        }

        public SqlDataReader GetSqlDataReaderBySQL(string SQL)
        {
            string strConn = "server=.;database=Test;trusted_connection=true;";
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cd = new SqlCommand(SQL, conn);
            SqlDataReader dr = null;

            if (conn.State == ConnectionState.Closed) { conn.Open(); }
            using (dr = cd.ExecuteReader())
            {
                int no = dr.GetOrdinal("LoginName");
                StringBuilder sb = new StringBuilder();
                while (dr.Read())
                {
                    sb.Append(dr.GetString(no));
                }
            }

            //SqlDataReader dr = cd.ExecuteReader();
            conn.Close();

            return dr;
        }
        //public List<PurchaseOrder> GetPurchaseOrderAll(string SQL)
        //{
        //    //string conn = System.Configuration.conf

        //    return null;
        //}
    }
}
