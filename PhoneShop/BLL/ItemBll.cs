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
    /// 商品Bll
    /// </summary>
    public class ItemBll
    {
        ItemInfo ItemInfo = new ItemInfo();
        ColorInfo ColorInfo = new ColorInfo();
        string cmd;
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

            if (content == "" || content == null || flag.ToString() == "" || flag.ToString() == null)
                return null;
            else
            {
                cmd = "select item.iid,iname,sid,intro,istate,itime,sales,model,price  from item  inner join itemtype on item.iid = itemtype.iid where  istate = 'true' and iname like '%" + content + "%'";

                switch (flag)
                {
                    case 1:
                        cmd += " order by itime desc";
                        break;
                    case 3:
                        cmd += " order by sales asc";
                        break;
                    case 4:
                        cmd += " order by price asc ";
                        break;
                    case 5:
                        cmd += " order by price desc";
                        break;
                }

                return new ItemDal().Query(cmd);
            }


        }

        /// <summary>
        /// 查询商铺商品
        /// </summary>
        /// <param name="sid">商家id</param>  
        /// <param name="content">查询文本</param>
        /// <param name="flag">排序模式</param>
        /// <param name="istate">上架状态</param>
        /// <returns>数据表</returns>
        public DataTable Query(string sid, string content, int flag, int state = 0)
        {
            //  模糊查询 state{0：查询全部；1：查询已上架；2：查询未上架}
            //  1:上市时间倒序；3：销量正序；4：价格正序；5：价格倒序
            if (sid == "" || sid == null || content == "" || content == null || flag.ToString() == "" || flag.ToString() == null)
                return null;
            else
            {
                cmd = "select item.iid,iname,sid,intro,istate,itime,sales,model,price  from item  inner join itemtype on item.iid = itemtype.iid  where sid like '%" + sid + "%'";

                switch (state)
                {
                    case 1:
                        cmd += "and istate = 'true'";
                        break;
                    case 2:
                        cmd += "and istate = 'false'";
                        break;
                    default:
                        return null;
                }

                cmd += "and iname like '%" + content + "%'";

                switch (flag)
                {
                    case 1:
                        cmd += " order by itime desc";
                        break;
                    case 3:
                        cmd += " order by sales asc";
                        break;
                    case 4:
                        cmd += " order by price asc ";
                        break;
                    case 5:
                        cmd += " order by price desc";
                        break;
                    default:
                        return null;
                }

                return new ItemDal().Query(cmd);
            }
        }

        /// <summary>
        /// 获取商品信息
        /// </summary>
        /// <param name="iid">商品id</param>
        /// <returns数据表></returns>
        public DataTable GetItemInfo(int iid)
        {
            if (iid.ToString() == null || iid.ToString() == "")
                return null;
            else
            {
                cmd = "select * from item where iid =" + iid;

                return new ItemDal().Query(cmd);
            }
        }

        /// <summary>
        /// 获取商品颜色
        /// </summary>
        /// <param name="iid">商品id</param>
        /// <returns>数据表</returns>
        public DataTable GetItemColor(int iid)
        {
            if (iid.ToString() == null || iid.ToString() == "")
                return null;
            else
            {
                return new ColorDal().Query(iid);
            }
        }

        /// <summary>
        /// 获取商品型号
        /// </summary>
        /// <param name="iid">商品id</param>
        /// <returns>数据表</returns>
        public DataTable GetItemType(int iid)
        {
            if (iid.ToString() == null || iid.ToString() == "")
                return null;
            else
            {
                return new ItemDal().QueryType(iid);
            }
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
            if (name == null || name == "" || sid == null || sid == "" || intro == "" || intro == null)
                return false;
            else
            {
                ItemInfo.iname = name;
                ItemInfo.sid = sid;
                ItemInfo.intro = intro;
                ItemInfo.istate = false;
                ItemInfo.itime = DateTime.Now;
                if (new ItemDal().Insert(ItemInfo) == -1)
                    return false;

                int iid = int.Parse(new ItemDal().Query("select iid  from  color where iid = ident_current('item')").Rows[0]["iid"].ToString());
               
                for (int i = 0; i <= color.Count; i++)
                {
                    ColorInfo.cid = color[i];
                    ColorInfo.iid = iid;

                    if (new ColorDal().Insert(ColorInfo) == -1)
                        return false;
                }

                for (int i = 0; i <= type.Count; i++)
                {
                    //赋值
                    string typeTable = type[0];
                    //分割
                    string[] typeString = typeTable.Split('-');


                    ItemInfo.type = typeString[0];
                    ItemInfo.price = int.Parse(typeString[1]);

                    if (new ItemDal().InsertType(ItemInfo) == -1)
                        return false;                 
                }

                return true;

            }
        }

        /// <summary>
        /// 更改商品简介
        /// </summary>
        /// <param name="iid">商品id</param>
        /// <param name="intro">商品简介</param>
        /// <returns></returns>
        public bool UpdateIntro(int iid, string intro)
        {
            if (iid.ToString() == null || iid.ToString() == "")
                return false;
            else
            {
                ItemInfo.iid = iid;
                ItemInfo.intro = intro;

                if (new ItemDal().Update(ItemInfo) == -1)
                    return false;

                return true;
            }
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

            if (iid.ToString() == "" || iid.ToString() == null || cid == null || cid == "" || flag.ToString() == null || flag.ToString() == "")
                return false;
            else
            {
                if (flag)
                {
                    ColorInfo.cid = cid;
                    ColorInfo.iid = iid;

                    if (new ColorDal().Insert(ColorInfo) == -1)
                        return false;

                    return true;
                }
                else
                {
                    ColorInfo.iid = iid;

                    if (new ColorDal().Delete(ColorInfo) == -1)
                        return false;

                    return true;
                }

            }
        }

        /// <summary>
        /// 更改型号
        /// </summary>
        /// <param name="iid">商品id</param>
        /// <param name="type">型号</param>
        /// <param name="price">价格</param>
        /// <param name="flag">更改模式</param>
        /// <returns></returns>
        public bool UpdateType(int iid, string type, int price, bool flag)
        {
            //  flag=true:添加；flag=false：删除；
            if (iid.ToString() == null || iid.ToString() == "" || type == null || type == "" || price.ToString() == "" || price.ToString() == null
                || flag.ToString() == null || flag.ToString() == "")
                return false;
            else
            {
                if (flag)
                {
                    ItemInfo.iid = iid;
                    ItemInfo.type = type;
                    ItemInfo.price = price;

                    if (new ItemDal().InsertType(ItemInfo) == -1)
                        return false;

                    return true;
                }
                else
                {
                    ItemInfo.iid = iid;

                    if (new ItemDal().DelteType(ItemInfo) == -1)
                        return false;

                    return true;
                }
            }
        }

        /// <summary>
        /// 上下架更改
        /// </summary>
        /// <param name="iid">商品id</param>
        /// <param name="flag">上下架状态</param>
        /// <returns></returns>
        public bool UpdateState(int iid, bool flag)
        {
            //  flag=true:上架；flag=false：下架； 
            if (iid.ToString() == null || iid.ToString() == "")
                return false;
            else
            {
                ItemInfo.iid = iid;
                ItemInfo.istate = flag;

                if (new ItemDal().Update(ItemInfo) == -1)
                    return false;

                return true;
            }
        }
    }
}
