using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 用户Bll
    /// </summary>
    public class UsersBll
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="pwd">密码</param>
        /// <returns>null：登录失败；其他：用户昵称</returns>
        public string Login(string phone, string pwd)
        {
            //  建议所有方法先看一遍，有些可以重复用
            //  登录相关操作全部由手机号当做编号
            //  登录成功返回用户昵称，失败返回null
            return null;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="pwd">密码</param>
        /// <returns>0：注册成功；1：重复号码；2：其他错误</returns>
        public int Register(string phone, string pwd)
        {
            //  用户id自增，昵称默认为手机号，收货地址默认为空
            return -1;
        }

        /// <summary>
        /// 更改密码
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="Opwd">原密码</param>
        /// <param name="Npwd">新密码</param>
        /// <returns>0：更改成功；1：原密码错误；2：其他错误</returns>
        public int ChangePwd(string phone, string Opwd, string Npwd)
        {
            //  先判定原密码是否正确，可以用login和setpwd方法
            return -1;
        }

        /// <summary>
        /// 设置密码
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="pwd">密码</param>
        /// <returns>true：成功；false：失败</returns>
        public bool SetPwd(string phone, string pwd)
        {

            return false;
        }

        /// <summary>
        /// 手机号是否存在
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns>true：存在；false：不存在</returns>
        public bool PhoneExist(string phone)
        {
            return false;
        }

        /// <summary>
        /// 更改昵称
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="name">昵称</param>
        /// <returns>true：成功；false：失败</returns>
        public bool UpdateName(string phone, string name)
        {
            return false;
        }

        /// <summary>
        /// 更新收货地址
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="address">地址</param>
        /// <returns>true：成功；false：失败</returns>
        public bool UpdateAddress(string phone, string address)
        {
            return false;
        }

        /// <summary>
        /// 获取收货地址
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns>null：无收货地址：其他：收货地址</returns>
        public string GetAddress(string phone)
        {
            return null;
        }

        /// <summary>
        /// 获取用户id
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns>-1：获取失败；其他：用户id</returns>
        public int GetId(string phone)
        {
            return -1;
        }
    }
}
