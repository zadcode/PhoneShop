using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 购物车Bll
    /// </summary>
    public class CartBll
    {
        /// <summary>
        /// 购物车查询
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns>数据表</returns>
        public DataTable GetFavor(int id)
        {
            //  排序为店家正序
            return null;
        }

        /// <summary>
        /// 添加购物车
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="itemid">商品id</param>
        /// <param name="color">颜色</param>
        /// <param name="model">型号</param>
        /// <param name="price">价格</param>
        /// <param name="count">数量</param>
        /// <returns>true：成功；false：失败</returns>
        public bool AddFavor(int id, int itemid, string color, string model, int price, int count)
        {
            //  店家id根据商品id获取，时间为当前时间
            return false;
        }

        /// <summary>
        /// 删除购物车
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="itemid">商品id</param>
        /// <returns>true：成功；false：失败</returns>
        public bool Delete(int id, int itemid)
        {
            return false;
        }

        /// <summary>
        /// 更改购物车
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="itemid">商品id</param>
        /// <param name="color">颜色</param>
        /// <param name="model">型号</param>
        /// <param name="price">价格</param>
        /// <param name="count">数量</param>
        /// <returns>true：成功；false：失败</returns>
        public bool UpdateFavor(int id, int itemid, string color, string model, int price, int count)
        {
            //  店家id根据商品id获取，时间为当前时间
            return false;
        }
    }
}
