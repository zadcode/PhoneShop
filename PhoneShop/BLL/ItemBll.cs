using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 商品Bll
    /// </summary>
    public class ItemBll
    {
        /// <summary>
        /// 商品查询
        /// </summary>
        /// <param name="content">查询文本</param>
        /// <param name="flag">排序模式</param>
        /// <returns>数据表</returns>
        public DataTable Query(string content, int flag)
        {
            //  模糊查询 只查询已上架的商品
            //  1:上市时间倒序；3：销量正序；4：价格正序；5：价格倒序
            return null;
        }

        /// <summary>
        /// 查询商铺商品
        /// </summary>
        /// <param name="sid">商家id</param>  
        /// <param name="content">查询文本</param>
        /// <param name="flag">排序模式</param>
        /// <param name="isSale">上架状态</param>
        /// <returns>数据表</returns>
        public DataTable Query(string sid, string content, int flag, int state = 0)
        {
            //  模糊查询 state{0：查询全部；1：查询已上架；2：查询未上架}
            //  1:上市时间倒序；3：销量正序；4：价格正序；5：价格倒序
            return null;
        }

        /// <summary>
        /// 获取商品信息
        /// </summary>
        /// <param name="iid">商品id</param>
        /// <returns数据表></returns>
        public DataTable GetItemInfo(int iid)
        {
            return null;
        }

        /// <summary>
        /// 获取商品颜色
        /// </summary>
        /// <param name="iid">商品id</param>
        /// <returns数据表></returns>
        public DataTable GetItemColor(int iid)
        {
            return null;
        }

        /// <summary>
        /// 获取商品型号
        /// </summary>
        /// <param name="iid">商品id</param>
        /// <returns数据表></returns>
        public DataTable GetItemType(int iid)
        {
            return null;
        }

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="name">商品名</param>
        /// <param name="sid">店家id</param>
        /// <param name="intro">简介</param>
        /// <param name="color">颜色列表</param>
        /// <param name="type">型号列表</param>
        /// <returns></returns>
        public bool AddItem(string name, string sid, string intro, List<string> color, List<string> type)
        {
            //  颜色列表string格式为（'颜色1'，'颜色2'）
            //  型号列表string格式为（'型号1-价格1'，'型号2-价格2'）
            //  可以先创建商品，然后依次添加颜色与型号
            return false;
        }

        /// <summary>
        /// 更改商品简介
        /// </summary>
        /// <param name="iid">商品id</param>
        /// <param name="intro">商品简介</param>
        /// <returns></returns>
        public bool UpdateIntro(int iid, string intro)
        {
            return false;
        }

        /// <summary>
        /// 更改颜色
        /// </summary>
        /// <param name="iid">商品id</param>
        /// <param name="cid">颜色</param>
        /// <param name="flag">更改模式</param>
        /// <returns></returns>
        public bool UpdateColor(int iid, string cid, bool flag)
        {
            //  flag=true:添加；flag=false：删除；
            //  图片方面暂时不管
            return false;
        }

        /// <summary>
        /// 更改颜色
        /// </summary>
        /// <param name="iid">商品id</param>
        /// <param name="type">型号</param>
        /// <param name="price">价格</param>
        /// <param name="flag">更改模式</param>
        /// <returns></returns>
        public bool UpdateType(int iid, string type,int price, bool flag)
        {
            //  flag=true:添加；flag=false：删除；
            return false;
        }

        /// <summary>
        /// 上下架更改
        /// </summary>
        /// <param name="iid">商品id</param>
        /// <param name="flag">上下架状态</param>
        /// <returns></returns>
        public bool UpdateState(int iid,bool flag)
        {
            //  flag=true:上架；flag=false：下架； 
            return false;
        }
    }
}
