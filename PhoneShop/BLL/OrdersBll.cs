using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 订单Bll
    /// </summary>
    public class OrdersBll
    {
        /// <summary>
        /// 生成订单
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="sid">商家id</param>
        /// <param name="items">true：成功；false：失败</param>
        public bool CreateOrder(int id,string sid,List<string> items)
        {
            //  先创建订单，编号自增，状态默认为0(代发货)，时间为当前时间
            //  获取创建的订单的编号，（sql有获取上次生成编号的操作，可以搜ident_current）
            //  items中string的格式为："商品id-颜色id-价格-型号-数量" ('-'为分隔符)
            //  编号为之前生成的编号
            return false;
        }

        /// <summary>
        /// 更改订单状态
        /// </summary>
        /// <param name="oid">订单id</param>
        /// <param name="flag">状态</param>
        /// <returns>true：成功；false：失败</returns>
        public bool ChangeState(int oid,int flag)
        {
            //  flag=1 => istate=1(改为已发货) ; flag=2 => istate=2(改为已签收)
            //  收货时要对订单内所有的商品销量进行增加
            return false;
        }

        /// <summary>
        /// 查询店家订单信息
        /// </summary>
        /// <param name="sid">商家id</param>
        /// <param name="flag">查询模式</param>
        /// <returns>true：成功；false：失败</returns>
        public DataTable StoreQuery(string sid,int flag = 0)
        {
            //  flag=0 查询该商铺全部订单；flag=1 查询代发货订单；flag=2 查询已发货；flag=3 已签收
            //  排序为时间倒序
            return null;
        }

        public DataTable UserQuery(int id,int flag = 0)
        {
            //  flag=0 查询该用户全部订单；flag=1 查询代发货订单；flag=2 查询已发货；flag=3 已签收
            //  排序为时间倒序
            return null;
        }
    }
}
