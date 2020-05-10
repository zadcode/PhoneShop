using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Model;
namespace BLL
{
    /// <summary>
    /// 收藏Bll
    /// </summary>
    public class FavorBll
    {
        FavorInfo favor = new FavorInfo();
        string cmd;
        /// <summary>
        /// 收藏查询
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns>数据表</returns>
        public DataTable GetFavor(int id)
        {
            //  排序为时间倒序
            if (id.ToString() == null || id.ToString() == "")
                return null;
            else
            {
                cmd = "select *  from favor where uid = " + id + " order by time desc";
                return new FavorDal().Query(cmd);
            }
        }

        /// <summary>
        /// 添加收藏
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="itemid">商品id</param>
        /// <returns>true：成功；false：失败</returns>
        public bool AddFavor(int id, int itemid)
        {
            //  店家id根据商品id获取，时间为当前时间
            if (id.ToString() == "" || id.ToString() == null || itemid.ToString() == null || itemid.ToString() == "")
                return false;
            else
            {
                favor.iid = itemid;
                favor.sid = new ItemDal().QuerySid(itemid).Rows[0]["sid"].ToString();
                favor.uid = id;
                favor.time = DateTime.Now.ToString();

                if (new FavorDal().Insert(favor) == -1)
                    return false;

                return true;
            }
        }

        /// <summary>
        /// 删除收藏
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="itemid">商品id</param>
        /// <returns>true：成功；false：失败</returns>
        public bool Delete(int id, int itemid)
        {
            if (id.ToString() == null || id.ToString() == "" || itemid.ToString() == null || itemid.ToString() == "")
                return false;
            else
            {
                favor.uid = id;
                favor.iid = itemid;

                if (new FavorDal().Delete(favor) == -1)
                    return false;

                return true;
            }
        }
    }

}
