using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Helper;
using System.Data;
using System.Data.SqlClient;
namespace Dal
{
    /// <summary>
    /// 收藏Dal
    /// </summary>
    public class FavorDal
    {
        List<SqlParameter> para = new List<SqlParameter>();

        /// <summary>
        /// 收藏查询
        /// </summary>
        /// <param name="cmd">sql语句</param>
        /// <returns>正确返回一个表，失败为空</returns>
        public DataTable Query(string cmd)
        {
            if (cmd != "" && cmd != null)
                return SqlHelper.Query(cmd);
            else
                return null;
        }

        /// <summary>
        /// 收藏添加
        /// </summary>
        /// <param name="favor"收藏信息></param>
        /// <returns>改成功返回被影响行数，失败返回-1</returns>
        public int Insert(FavorInfo favor)
        {
            try
            {
                string sql = "insert into favor values(@uid,@uid,@uid,@uid)";

                para.Add(new SqlParameter("@uid", favor.uid));
                para.Add(new SqlParameter("@sid", favor.sid));
                para.Add(new SqlParameter("@iid", favor.iid));
                para.Add(new SqlParameter("@time", favor.time));

                return SqlHelper.Update(sql, para);

            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 收藏删除
        /// </summary>
        /// <param name="favor"收藏信息></param>
        /// <returns>改成功返回被影响行数，失败返回-1</returns>
        public int Delete(FavorInfo favor)
        {
            try
            {
                string sql = "delete favor where uid = @uid and sid = @sid";

                para.Add(new SqlParameter("@uid", favor.uid));
                para.Add(new SqlParameter("@sid", favor.sid));

                return SqlHelper.Update(sql, para);
            }
            catch
            {
                return -1;
            }

        }

    }
}
