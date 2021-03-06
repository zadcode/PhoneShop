﻿using System;
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
    /// 订单Bll
    /// </summary>
    public class OrdersBll
    {

        OrdersInfo OrdersInfo = new OrdersInfo();
        OrdersDal orders = new OrdersDal();
        ItemInfo ItemInfo = new ItemInfo();

        string cmd;

        /// <summary>
        /// 生成订单
        /// </summary>
        /// <param name="id">用户uid</param>
        /// <param name="sid">商家id</param>
        /// <param name="items">true：成功；false：失败</param>
        public bool CreateOrder(int uid, string sid, List<string> items)
        {
            //  先创建订单，编号自增，状态默认为0(代发货)，时间为当前时间
            //  获取创建的订单的编号，（sql有获取上次生成编号的操作，可以搜ident_current）
            //  items中string的格式为："商品id-颜色id-价格-型号-数量" ('-'为分隔符)
            //  编号为之前生成的编号

            if (uid.ToString() == null || uid.ToString() == "" || sid == null || sid == "")
                return false;
            else
            {
                OrdersInfo.uid = uid.ToString();
                OrdersInfo.sid = sid;
                OrdersInfo.ostate = 0;
                OrdersInfo.otime = DateTime.Now.ToString();

                if (orders.Insert(OrdersInfo) == -1)
                    return false;

                string[] item = items.ToString().Split('-');

                cmd = "select oid  from orders where oid = ident_current('orders')";

                OrdersInfo.oid = Convert.ToInt32(orders.QueryGetValue(cmd));
                OrdersInfo.iid = int.Parse(item[0]);
                OrdersInfo.cid = item[1];
                OrdersInfo.price = int.Parse(item[2]);
                OrdersInfo.model = item[3];
                OrdersInfo.nums = int.Parse(item[4]);

                if (orders.insertSinfo(OrdersInfo) == -1)
                    return false;

                return true;

            }
        }

        /// <summary>
        /// 更改订单状态
        /// </summary>
        /// <param name="oid">订单id</param>
        /// <param name="flag">状态</param>
        /// <returns>true：成功；false：失败</returns>
        public bool ChangeState(int oid, int flag)
        {
            //  flag=1 => ostate=1(改为已发货) ; flag=2 => ostate=2(改为已签收)
            //  收货时要对订单内所有的商品销量进行增加
            if (oid.ToString() == "" || oid.ToString() == null || flag.ToString() == "" || flag.ToString() == null)
                return false;
            else
            {
                OrdersInfo.oid = oid;
                OrdersInfo.ostate = flag;

                if (orders.Update(OrdersInfo) == -1)
                    return false;


                int iid = int.Parse(orders.Query("select iid  from  ordreinfo where oid = " + oid).Rows[0]["iid"].ToString());

                int sales = int.Parse(new ItemDal().QuerySales(iid).Rows[0]["sales"].ToString());

                if (iid.ToString() == null && iid.ToString() == "")
                {
                    ItemInfo.iid = iid;
                    ItemInfo.sales = sales + 1;

                    if (new ItemDal().Update(ItemInfo) == -1)
                        return false;
                }

                return true;
            }
        }

        /// <summary>
        /// 查询店家订单信息倒序
        /// </summary>
        /// <param name="sid">商家id</param>
        /// <param name="flag">查询模式</param>
        /// <returns>true：成功；false：失败</returns>
        public DataTable StoreQuery(string sid, int flag = 0)
        {
            //  flag=0 查询该商铺全部订单；flag=1 查询代发货订单；flag=2 查询已发货；flag=3 已签收
            //  排序为时间倒序
            if (sid == null || sid == "")
                return null;
            else
            {
                cmd = "select * from orders where sid = " + sid + "";


                switch (flag)
                {
                    case 0:
                        cmd += "order by time desc";                       
                        break;
                    case 1:
                        cmd += "ostate = 0 order by time desc";
                        break;
                    case 2:
                        cmd += "ostate = 1 order by time desc";
                        break;
                    case 3:
                        cmd += "ostate = 2 order by time desc";
                        break;
                    default:
                        return null;
                       
                }

                return orders.Query(cmd);              
            }
        }

        /// <summary>
        /// 查询用户的订单
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="flag">订单状态</param>
        /// <returns>null:失败</returns>
        public DataTable UserQuery(int uid, int flag = 0)
        {
            //  flag=0 查询该用户全部订单；flag=1 查询代发货订单；flag=2 查询已发货；flag=3 已签收
            //  排序为时间倒序 
            if (uid.ToString() == null || uid.ToString() == "")
                return null;
            else
            {
                cmd = "select * from orders where uid = " + uid + "";

                switch (flag)
                {
                    case 0:
                        cmd += "order by time desc";
                        break;
                    case 1:
                        cmd += "ostate = 0 order by time desc";
                        break;
                    case 2:
                        cmd += "ostate = 1 order by time desc";
                        break;
                    case 3:
                        cmd += "ostate = 2 order by time desc";
                        break;
                    default:
                        return null;
                }

                return orders.Query(cmd);               
            }
        }
    }
}
