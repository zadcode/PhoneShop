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
    /// 商品Dal
    /// </summary>
    public class ItemDal
    {
        List<SqlParameter> para = new List<SqlParameter>();

        /// <summary>
        /// 商品查询
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
        /// 添加商品
        /// </summary>
        /// <param name="item">商品信息</param>
        /// <returns>改成功返回被影响行数，失败返回-1</returns>
        public int update(ItemInfo item)
        {
            try
            {
                string sql = "update store set";

                if (item.intro != "" && item.intro != null)
                {
                    sql = "intro = @intro,";
                    para.Add(new SqlParameter("@intro", item.intro));
                }

                if (item.sales.ToString() != "" && item.sales.ToString() != null)
                {
                    sql = "sales=@sales,";
                    para.Add(new SqlParameter("@sales", item.sales));
                }

                if (item.istate.ToString() != "" && item.istate.ToString() != null)
                {
                    sql = "istate = @istate,";
                    para.Add(new SqlParameter("@istate", item.istate));
                }

                sql = sql.Remove(sql.Length - 1, 1) + "where  iid = @iid";
                para.Add(new SqlParameter("@iid", item.iid));

                return SqlHelper.Update(sql,para);
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="item">商品信息</param>
        /// <returns>改成功返回被影响行数，失败返回-1</returns>
        public int Insert(ItemInfo item)
        {
            try
            {
                string sql = "insert item values(@iname,@sid.@intro,@istate,@itime,@sales)";

                para.Add(new SqlParameter("@iname", item.iname));
                para.Add(new SqlParameter("@sid", item.sid));
                para.Add(new SqlParameter("@intro", item.intro));
                para.Add(new SqlParameter("@istate", item.istate));
                para.Add(new SqlParameter("@itime", item.itime));
                para.Add(new SqlParameter("@sales", item.sales));

                return SqlHelper.Update(sql, para);
            }
            catch
            {
                return -1;
            }
        }


        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="item">商品信息</param>
        /// <returns>改成功返回被影响行数，失败返回-1</returns>
        public int Delete(ItemInfo item)
        {
            try
            {
                string sql = "delete item where iid = @iid";

                para.Add(new SqlParameter("@iid", item.iid));

                return SqlHelper.Update(sql, para);
            }
            catch
            {
                return -1;
            }
        }

    }
}
