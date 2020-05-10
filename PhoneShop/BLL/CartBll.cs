using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dal;
namespace BLL
{
    /// <summary>
    /// 购物车Bll
    /// </summary>
    public class CartBll
    {
        CartInfo cart = new CartInfo();
        string cmd;
        /// <summary>
        /// 购物车查询
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns>数据表</returns>
        public DataTable GetCart(int id)
        {
            //  排序为店家正序,时间倒序
            if (id.ToString() == null || id.ToString() == "")
                return null;
            else
            {
                cmd = "select * from cart where uid = " + id + " order by sid , time desc";
                return new CartDal().Query(cmd);
            }
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
        public bool AddCart(int id, int itemid, string color, string model, int price, int count)
        {
            //  店家id根据商品id获取，时间为当前时间
            if (id.ToString() == null || id.ToString() == "" || itemid.ToString() == "" || itemid.ToString() == null || color == null
                 || color == "" || model == null || model == "" || price.ToString() == null || price.ToString() == "" || count.ToString() == "" || count.ToString() == null)
                return false;
            else
            {
                cart.uid = id;
                cart.iid = itemid;
                cart.sid = new ItemDal().QuerySid(itemid).Rows[0]["sid"].ToString();
                cart.cid = color;
                cart.model = model;
                cart.price = price;
                cart.nums = count;
                cart.time = DateTime.Now.ToString();

                if (new CartDal().insert(cart) == -1)
                    return false;

                return true;
            }
        }

        /// <summary>
        /// 删除购物车
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="itemid">商品id</param>
        /// <returns>true：成功；false：失败</returns>
        public bool Delete(int id, int itemid)
        {
            if (id.ToString() == null || id.ToString() == null || itemid.ToString() == null || itemid.ToString() == "")
                return false;
            else
            {
                cart.uid = id;
                cart.iid = itemid;

                if (new CartDal().delete(cart) == -1)
                    return false;

                return true;
            }
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
        public bool UpdateCart(int id, int itemid, string color, string model, int price, int count)
        {
            //  店家id根据商品id获取，时间为当前时间
            if (id.ToString() == null || id.ToString() == "" || itemid.ToString() == "" || itemid.ToString() == null || color == null
                 || color == "" || model == null || model == "" || price.ToString() == null || price.ToString() == "" || count.ToString() == "" || count.ToString() == null)
                return false;
            else
            {
                cart.iid = id;
                cart.iid = itemid;
                cart.cid = color;
                cart.model = model;
                cart.nums = count;

                if (new CartDal().update(cart) == -1)
                    return false;

                return true;
            }
        }
    }
}
