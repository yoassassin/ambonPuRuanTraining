using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SqlDataReaderTest
{
    class Program
    {
        static SqlConnection conn = null;
        static SqlConnection CreateConnection(string strConn)
        {
            return conn = new SqlConnection(strConn);
        }
        static void Main(string[] args)
        {
            SqlDataReader reader = testSessionOfReader();
            Console.WriteLine(reader);
            Console.WriteLine(conn.State);
            delete();
            Console.WriteLine(conn.State);
            SqlDataReader reader2 = testSessionOfReader();
            Console.WriteLine(conn.State);
            Console.Read();
        }

        static SqlDataReader testSessionOfReader()
        {
            string strConn = ConfigurationManager.ConnectionStrings["MyConnStr"].ConnectionString;
            CreateConnection(strConn);
            try { 
            conn.Open();
            SqlCommand cmd = new SqlCommand("select top 10 * from student1", conn);
            string cmd1Sql = "delete from student1 where sno in( '22','23')";
            SqlCommand cmd1 = new SqlCommand(cmd1Sql, conn);
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);//
                //SqlDataReader reader1 = cmd1.ExecuteReader(CommandBehavior.CloseConnection);//
                //1行行读出来
                //while (reader.Read())
                //{
                //    Console.WriteLine(reader.GetInt32(0));
                //}
            //或者1行行 读取 1列的值

                //while (reader.Read())
                //{
                //    Console.WriteLine(String.Format("{0}, {1},{2}", reader[0], reader[1], reader[2]));
                //}
                //reader.Close();
                //conn.Close();
            return reader;
            }
            catch
            {
               
                throw;
            }
            //conn.Close();//一个command一个连接。
            //conn.Open();//得重新再开一个
            //int i = cmd1.ExecuteNonQuery();//删除2个, i = 2
            //object o = cmd.ExecuteScalar();//第一行第一列的值,sno
            //Console.WriteLine(i+"o="+o);
        }

        static int delete()
        {
            string strConn = ConfigurationManager.ConnectionStrings["MyConnStr"].ConnectionString;
            CreateConnection(strConn);
            conn.Open();
            string cmd1Sql = "delete from student1 where sno in( '19')";
            SqlCommand cmd1 = new SqlCommand(cmd1Sql, conn);

            int i = cmd1.ExecuteNonQuery();//删除2个, i = 2

            return i;
        }
    }
}
