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
    /// 商品颜色
    /// </summary>
    public class ColorDal
    {
        List<SqlParameter> para = new List<SqlParameter>();

        /// <summary>
        /// 颜色查询
        /// </summary>
        /// <param name="iid">商品id</param>
        /// <returns>失败返回null，成功返回一个表</returns>
        public DataTable Query(int iid)
        {
            try
            {
                string cmd = "select  cid  from color where iid = " + iid;

                return SqlHelper.Query(cmd);
            }
            catch
            {
                return null;
            }        
        }

        /// <summary>
        /// 根据sql语句查询
        /// </summary>
        /// <param name="cmd">sql语句</param>
        /// <returns>失败返回null，成功返回一个表</returns>
        public DataTable Qurey(string cmd)
        {
            try
            {               
                return SqlHelper.Query(cmd);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 颜色添加
        /// </summary>
        /// <param name="color">颜色信息</param>
        /// <returns>失败返回-1，成功返回一个表</returns>
        public int Insert(ColorInfo color)
        {
            try
            {
                string sql = "insert into color values(@cid,@iid)";

                para.Add(new SqlParameter("@cid", color.cid));
                para.Add(new SqlParameter("@iid", color.iid));

                return SqlHelper.Update(sql, para);
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 颜色修改
        /// </summary>
        /// <param name="color">颜色信息</param>
        /// <returns>失败返回-1，成功返回一个表</returns>
        public int Upadte(ColorInfo color)
        {
            try
            {
                string sql = "update  color set cid = @cid where iid = @iid";

                para.Add(new SqlParameter("@cid",color.cid));
                para.Add(new SqlParameter("@iid",color.iid));

                return SqlHelper.Update(sql,para);
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 颜色删除
        /// </summary>
        /// <param name="color">颜色信息</param>
        /// <returns>失败返回-1，成功返回一个表</returns>
        public int Delete(ColorInfo color)
        {
            try
            {
                string sql = "delete color where iid = @iid";

                para.Add(new SqlParameter("@iid", color.iid));

                return SqlHelper.Update(sql,para);
            }
            catch
            {
                return -1;
            }
        }
    }
}
