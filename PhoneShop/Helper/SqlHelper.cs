using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Helper
{
    public class SqlHelper
    {
        // 连接字符串
        static string connStr = ConfigurationManager.ConnectionStrings["connstr"].ToString();
        /// <summary>
        /// Sql连接字符串
        /// </summary>
        public static string ConnStr
        {
            get
            {
                return connStr;
            }
            set
            {
                connStr = value;
            }

        }

        static SqlCommand sqlcmd;
        static SqlConnection conn = new SqlConnection(connStr);

        //  更新数据
        /// <summary>
        /// 执行Sql语句，并返回受影响行数
        /// </summary>
        /// <param name="cmd">Sql语句</param>
        /// <param name="sp">SqlParameter成员</param>
        /// <returns>-1为执行失败；其余为受影响行数</returns>
        public static int Update(string cmd, List<SqlParameter> sp)
        {
            try
            {
                sqlcmd = new SqlCommand(cmd, conn);

                //  为成员赋值
                foreach (SqlParameter i in sp)
                    sqlcmd.Parameters.Add(i);

                ////语句检查
                ///
                string cmdstr = sqlcmd.CommandText;
                foreach (SqlParameter i in sqlcmd.Parameters)
                    cmdstr = cmdstr.Replace(i.ParameterName, i.Value.ToString());
                ////    

                //  执行语句
                conn.Open();
                int result = sqlcmd.ExecuteNonQuery();
                conn.Close();

                //  返回受影响行数
                return result;
            }
            catch
            {
                //  出错时关闭连接
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();

                return -1;
            }
        }

        //  查询数据
        /// <summary>
        /// 根据Sql语句返回查询到的数据表
        /// </summary>
        /// <param name="cmd">Sql语句</param>
        /// <returns>返回的数据表;错误时返回null</returns>
        public static DataTable Query(string cmd)
        {
            SqlDataAdapter sa = new SqlDataAdapter(cmd, conn);
            DataTable dt = new DataTable();

            try
            {
                conn.Open();
                sa.Fill(dt);
                conn.Close();

                return dt;
            }
            catch
            {
                //  出错时关闭连接
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();

                return null;
            }
        }


        //  查询数据
        /// <summary>
        /// 根据Sql语句返回查询到的数据表
        /// </summary>
        /// <param name="cmd">Sql语句</param>
        /// <returns>返回的数据表;错误时返回null</returns>
        public static DataTable Query(string cmd, List<SqlParameter> sp)
        {
            sqlcmd = new SqlCommand(cmd, conn);

            //  为成员赋值
            foreach (SqlParameter i in sp)
                sqlcmd.Parameters.Add(i);
            SqlDataAdapter sa = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();

            string cmdstr = sqlcmd.CommandText;
            foreach (SqlParameter i in sqlcmd.Parameters)
                cmdstr = cmdstr.Replace(i.ParameterName, i.Value.ToString());

            try
            {
                conn.Open();
                sa.Fill(dt);
                conn.Close();

                return dt;
            }
            catch
            {
                //  出错时关闭连接
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();

                return null;
            }
        }// 已检查

        /// <summary>
        /// 根据语句进行查询，并返回查询到的第一个值
        /// </summary>
        /// <param name="cmd">需要查询的语句</param>
        /// <returns>表内的第一个值，无返回值则返回null</returns>
        public static object GetValue(string cmd)
        {
            sqlcmd = new SqlCommand(cmd, conn);
            object value = null;
            try
            {
                conn.Open();

                SqlDataReader sr = sqlcmd.ExecuteReader();
                if (sr.Read())
                    value = sr[0];

                conn.Close();
                return value;
            }
            catch
            {
                //  出错时关闭连接
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();

                return null;
            }
        }

    }
}

