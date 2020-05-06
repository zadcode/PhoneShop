using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Helper;
using System.Data.SqlClient;
using System.Data;
namespace Dal
{
    /// <summary>
    /// 购物车Dal
    /// </summary>
    public class CartDal
    {
        List<SqlParameter> para = new List<SqlParameter>();

        /// <summary>
        /// 购物车查询
        /// </summary>
        /// <param name="cmd">SQL语句</param>
        /// <returns>正确返回一个表，失败为空</returns>
        public DataTable Query(string cmd)
        {
            if (cmd != "" && cmd != null)
                return SqlHelper.Query(cmd);
            else
                return null;
        }

        /// <summary>
        ///  购物车添加
        /// </summary>
        /// <param name="cart">购物车信息</param>
        /// <returns>改成功返回被影响行数，失败返回-1</returns>
        public int insert(CartInfo cart)
        {
            try
            {
                string sql = "insert into cart values (@uid,@sid,@iid,@cid,@model,@price,@nums,@time)";

                para.Add(new SqlParameter("@uid",cart.uid));
                para.Add(new SqlParameter("@sid",cart.sid));
                para.Add(new SqlParameter("@iid",cart.iid));
                para.Add(new SqlParameter("@cid",cart.cid));
                para.Add(new SqlParameter("@model",cart.model));
                para.Add(new SqlParameter("@price",cart.price));
                para.Add(new SqlParameter("@nums",cart.nums));
                para.Add(new SqlParameter("@time",cart.time));

                return SqlHelper.Update(sql,para);
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        ///  购物车删除
        /// </summary>
        /// <param name="cart">购物车信息</param>
        /// <returns>改成功返回被影响行数，失败返回-1</returns>
        public int delete(CartInfo cart)
        {
            try
            {
                string sql = "delte cart where uid  = @uid";

                para.Add(new SqlParameter("@uid", cart.uid));

                return SqlHelper.Update(sql, para);
            }
            catch
            {
                return -1;
            }
        }
    }
}
