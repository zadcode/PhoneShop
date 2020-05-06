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
    /// 订单Dal
    /// </summary>
    public class OrdersDal
    {
        List<SqlParameter> para = new List<SqlParameter>();
        /// <summary>
        /// 订单查询
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
        /// 订单添加
        /// </summary>
        /// <param name="orders">订单信息</param>
        /// <returns>改成功返回被影响行数，失败返回-1</returns>
        public int Insert(OrdersInfo orders)
        {
            try
            {
                string sql = "insert into orders value(@uid,@sid,@ostate,@time)";

                para.Add(new SqlParameter("@uid", orders.uid));
                para.Add(new SqlParameter("@sid", orders.sid));
                para.Add(new SqlParameter("@ostate", orders.istate));
                para.Add(new SqlParameter("@time", orders.otime));

                return SqlHelper.Update(sql, para);
            }
            catch
            {
                return -1;
            }

        }

        /// <summary>
        /// 订单删除
        /// </summary>
        /// <param name="orders">订单信息</param>
        /// <returns>改成功返回被影响行数，失败返回-1</returns>
        public int Delete(OrdersInfo orders)
        {
            try
            {
                string sql = "delete orders where oid = @oid";

                para.Add(new SqlParameter("@oid", orders.oid));



                return SqlHelper.Update(sql, para);
            }
            catch
            {
                return -1;
            }
        }

      //下面为订单详细

        /// <summary>
        /// 订单详细查询
        /// </summary>
        /// <param name="cmd">sql语句</param>
        /// <returns></returns>
        public DataTable QuerySinfo(string cmd)
        {
            if (cmd != "" && cmd != null)
                return SqlHelper.Query(cmd);
            else
                return null;
        }
        /// <summary>
        /// 订单详细删除
        /// </summary>
        /// <param name="orders">订单信息</param>
        /// <returns>改成功返回被影响行数，失败返回-1</returns>
        public int insertSinfo(OrdersInfo orders)
        {
            try
            {
                string sql = "insert into orders values(@cid,@price,@model,@nums)";

                para.Add(new SqlParameter("@cid", orders.cid));
                para.Add(new SqlParameter("@price", orders.price));
                para.Add(new SqlParameter("@model", orders.model));
                para.Add(new SqlParameter("@nums", orders.nums));

                return SqlHelper.Update(sql, para);
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 订单详细修改
        /// </summary>
        /// <param name="orders">订单信息</param>
        /// <returns>改成功返回被影响行数，失败返回-1</returns>
        public int updateSinfo(OrdersInfo orders)
        {
            try
            {
                string sql = "update ordreinfo set ";

                if (orders.cid != null && orders.cid != "")
                {
                    sql += "cid = @cid";
                    para.Add(new SqlParameter("@cid", orders.cid));
                }

                if (orders.nums.ToString() != null && orders.nums.ToString() != "")
                {
                    sql += "nums = @nums";
                    para.Add(new SqlParameter("@nums", orders.nums));
                }

                sql += "where oid = @oid";
                para.Add(new SqlParameter("@oid", orders.oid));
                return SqlHelper.Update(sql, para);
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 订单详细删除
        /// </summary>
        /// <param name="orders">订单信息</param>
        /// <returns>改成功返回被影响行数，失败返回-1</returns>
        //与delete同时删除
        public int DeteleSinfo(OrdersInfo orders)
        {
            try
            {
                string sql = "delete ordreinfo where oid = @oid";

                para.Add(new SqlParameter("@oid", orders.oid));

                return SqlHelper.Update(sql, para);
            }
            catch
            {
                return -1;
            }

        }


    }
}
