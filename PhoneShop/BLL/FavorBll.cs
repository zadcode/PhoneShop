﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 收藏Bll
    /// </summary>
    public class FavorBll   
    {
        /// <summary>
        /// 收藏查询
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns>数据表</returns>
        public DataTable GetFavor(int id)
        {
            //  排序为时间倒序
            return null;
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
            return false ;
        }

        /// <summary>
        /// 删除收藏
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="itemid">商品id</param>
        /// <returns>true：成功；false：失败</returns>
        public bool Delete(int id,int itemid)
        {
            return false;
        }
    }

}