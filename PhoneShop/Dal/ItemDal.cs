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
        /// 商品型号查询
        /// </summary>
        /// <param name="iid">商品id</param>
        /// <returns>正确返回一个表，失败为空</returns>
        public DataTable QueryType(int iid)
        {
            try
            {
                if (iid.ToString() != "" || iid.ToString() != null)
                {
                    string cmd = "select model from itemtype where iid = @iid";

                    return Helper.SqlHelper.Query(cmd);
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 店家id查询
        /// </summary>
        /// <param name="iid">商品id</param>
        /// <returns>正确返回一个表，失败为空</returns>
        public DataTable QuerySid(int iid)
        {
            try
            {
                if (iid.ToString() != "" || iid.ToString() != null)
                {
                    string cmd = "select sid from item where iid = @iid";

                    return Helper.SqlHelper.Query(cmd);
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 销量查询
        /// </summary>
        /// <param name="iid">商品id</param>
        /// <returns>正确返回一个表，失败为空</returns>
        public DataTable QuerySales(int iid)
        {

            try
            {
                if (iid.ToString() != "" || iid.ToString() != null)
                {
                    string cmd = "select sales from item where  iid = @iid";

                    return Helper.SqlHelper.Query(cmd);
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 添加商品型号
        /// </summary>
        /// <param name="item">商品信息</param>
        /// <returns>改成功返回被影响行数，失败返回-1</returns>
        public int InsertType(ItemInfo item)
        {
            try
            {
                string sql = "insert into itemtype values(@iid,@type,@price)";

                para.Add(new SqlParameter("@iid", item.iid));
                para.Add(new SqlParameter("@type", item.type));
                para.Add(new SqlParameter("@price", item.price));

                return SqlHelper.Update(sql, para);

            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 删除商品型号
        /// </summary>
        /// <param name="item">商品信息</param>
        /// <returns>改成功返回被影响行数，失败返回-1</returns>
        public int DelteType(ItemInfo item)
        {
            try
            {
                string sql = "delete itemtype where iid = @iid";

                para.Add(new SqlParameter("@iid", item.iid));

                return SqlHelper.Update(sql, para);

            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 修改商品型号
        /// </summary>
        /// <param name="item">商品信息</param>
        /// <returns>改成功返回被影响行数，失败返回-1</returns>
        public int UdateType(ItemInfo item)
        {
            try
            {
                string sql = "update  itemtype set";

                if (item.type == null && item.type == "")
                {
                    sql += " model = @model,";
                    para.Add(new SqlParameter("@model", item.type));

                }

                if (item.price.ToString() == null && item.price.ToString() == "")
                {
                    sql += "price = @price,";
                    para.Add(new SqlParameter("@price", item.price));
                }

                sql = sql.Remove(sql.Length - 1, 1);

                sql += "where iid = @iid";
                para.Add(new SqlParameter("@iid", item.iid));

                return SqlHelper.Update(sql, para);

            }
            catch
            {
                return -1;
            }
        }



        /// <summary>
        /// 修改商品
        /// </summary>
        /// <param name="item">商品信息</param>
        /// <returns>改成功返回被影响行数，失败返回-1</returns>
        public int Update(ItemInfo item)
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
                    sql = "sales= @sales,";
                    para.Add(new SqlParameter("@sales", item.sales));
                }

                if (item.istate.ToString() != "" && item.istate.ToString() != null)
                {
                    sql = "istate = @istate,";
                    para.Add(new SqlParameter("@istate", item.istate));
                }

                sql = sql.Remove(sql.Length - 1, 1);

                sql += "where  iid = @iid";
                para.Add(new SqlParameter("@iid", item.iid));

                return SqlHelper.Update(sql, para);
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
                string sql = "insert into item values(@iname,@sid.@intro,@istate,@itime,@sales)";

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
