using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace 测试SQL最大连接数
{


        class Program
        {
            static void Main(string[] args)
            {
            string strConn = ConfigurationManager.ConnectionStrings["MyConnStr"].ConnectionString;
            string strConnMaxValue = ConfigurationManager.ConnectionStrings["MyConnStrAddPoolMaxValue"].ConnectionString; //设置了40000也没用，最大就是32767
              //int maxCount = 40000;
              //  List<SqlConnection> collection = new List<SqlConnection>();
              //  for (int i = 0; i < maxCount; i++)
              //  {
              //      Console.WriteLine(string.Format("成功创建连接对象{0}", i));
              //      var db = new SqlConnection(strConn);
              //      db.Open();//只能输出到100，然后等了15秒后报错了。
              //      collection.Add(db);
              //  }

            //第二段，开启了最大连接数为30000多
           int maxCount = 40000;
                List<SqlConnection> collection = new List<SqlConnection>();
                for (int i = 0; i < maxCount; i++)
                {
                    Console.WriteLine(string.Format("成功创建连接对象{0}", i));
                    var db = new SqlConnection(strConnMaxValue);
                db.Open();
                    collection.Add(db);
                }


            }
        }
}
