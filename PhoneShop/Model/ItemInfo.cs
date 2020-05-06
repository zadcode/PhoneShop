using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ItemInfo
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        public int iid;

        /// <summary>
        /// 商品名称
        /// </summary>
        public string iname;

        /// <summary>
        /// 店家编号
        /// </summary>
        public string sid;

        /// <summary>
        /// 商品简介
        /// </summary>
        public string intro;

        /// <summary>
        /// 商品状态
        /// </summary>
        public int istate;

        /// <summary>
        /// 商品添加的时间
        /// </summary>
        public DateTime itime;

        /// <summary>
        /// 商品销量
        /// </summary>
        public int sales;
    }
}
