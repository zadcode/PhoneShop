using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Model;
using Helper;
namespace Dal
{
    /// <summary>
    /// 商家Dal
    /// </summary>
    public class StoreDal
    {
        List<SqlParameter> para = new List<SqlParameter>();

        /// <summary>
        /// 进行店家信息查询
        /// </summary>
        /// <param name="cmd">查询的sql语句</param>
        /// <returns>正确返回一个表，失败为空</returns>
        public DataTable Query(string cmd ){

            if (cmd != string.Empty)
                return SqlHelper.Query(cmd);
            else
                return null;
        }

        /// <summary>
        /// 店家添加
        /// </summary>
        /// <param name="users">用户信息</param>
        /// <returns>改成功返回被影响行数，失败返回-1</returns>
        public int Insert(StoreInfo store) {

            try
            {
                string sql = "insert into store values (@sid @brand @spwd)";

                para.Add(new SqlParameter("@sid",store.sid));
                para.Add(new SqlParameter("@brand", store.brand));
                para.Add(new SqlParameter("@spwd", store.spwd));

                return SqlHelper.Update(sql,para);
            }
            catch {
                return -1;
            }

        }

        /// <summary>
        /// 店家修改
        /// </summary>
        /// <param name="users">用户信息</param>
        /// <returns>改成功返回被影响行数，失败返回-1</returns>
        public int Update( StoreInfo store ) {
            try{
                string sql = "update store set";

                if (store.spwd != "" && store.spwd != null)
                {
                    sql += "spwd = @spwd";
                    para.Add(new SqlParameter("@spwd",store.spwd));
                }

                sql += "where sid = @sid";
                para.Add(new SqlParameter("@sid",store.sid));
                return SqlHelper.Update(sql,para);

            }
            catch {
                return -1;
            }
        }
            
    }
}
