using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using System.Data;
using Helper;
namespace Dal
{
    /// <summary>
    /// 用户Dal
    /// </summary>
    public class UsersDal
    {

        List<SqlParameter> para = new List<SqlParameter>();

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="cmd">sql语句</param>
        /// <returns>正确返回一个表，失败为空</returns>
        public DataTable Query(string cmd)
        {
            if (cmd != string.Empty)
                return SqlHelper.Query(cmd);
            else
                return null;
        }

        /// <summary>
        /// 用户添加
        /// </summary>
        /// <param name="users">用户信息</param>
        /// <returns>改成功返回被影响行数，失败返回-1</returns>
        public int Insert(UsersInfo users)
        {

            try
            {
                //sql语言
                string sql = "insert into users values(@upwd,@uname,@phone,@address)";

                //赋值               
                para.Add(new SqlParameter("@upwd", users.upwd));
                para.Add(new SqlParameter("@uname", users.uname));
                para.Add(new SqlParameter("@phone", users.phone));
                para.Add(new SqlParameter("@address", users.address));

                //返回到sqlHelper中
                return SqlHelper.Update(sql, para);
            }
            catch
            {
                //失败返回-1
                return -1;
            }
        }

        /// <summary>
        /// 用户修改
        /// </summary>
        /// <param name="users">用户信息</param>
        /// <returns>改成功返回被影响行数，失败返回-1</returns>
        public int Update(UsersInfo users)
        {
            try
            {
                string sql = "update users set";

                //if判断昵称或密码
                if (users.uname != null && users.uname != "")
                {
                    sql += "uname = @uname,";
                    para.Add(new SqlParameter("@uname", users.uname));
                }

                if (users.upwd != null && users.upwd != "")
                {
                    sql += "upwd = @upwd,";
                    para.Add(new SqlParameter("@upwd", users.upwd));
                }

                if (users.address != null && users.address != "")
                {
                    sql += " address =@address,";
                    para.Add(new SqlParameter("@address", users.address));
                }

                //删除“，”并拼装
                sql = sql.Remove(sql.Length - 1, 1);
                sql += "where phone = @phone";
                para.Add(new SqlParameter("@phone", users.phone));

                return SqlHelper.Update(sql, para);
            }
            catch
            {
                return -1;
            }

        }
    }
}
