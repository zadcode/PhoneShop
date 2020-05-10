using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrdersInfo
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public int oid;

        /// <summary>
        /// 用户编号
        /// </summary>
        public string uid;

        /// <summary>
        /// 店家编号
        /// </summary>
        public string sid;

        /// <summary>
        /// 商品编号
        /// </summary>
        public int iid;

        /// <summary>
        /// 颜色编号
        /// </summary>
        public string cid;

        /// <summary>
        /// 订单状态
        /// </summary>
        public int ostate;

        /// <summary>
        /// 商品价格
        /// </summary>
        public int price;

        /// <summary>
        /// 商品型号
        /// </summary>
        public string model;

        /// <summary>
        /// 商品数量
        /// </summary>
        public int nums;

        /// <summary>
        /// 订单时间
        /// </summary>
        public string otime;
    }
}
