using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Model;

namespace BLL
{
    /// <summary>
    /// 用户Bll
    /// </summary>
    public class UsersBll
    {
        UsersDal users = new UsersDal();
        UsersInfo UsersInfo = new UsersInfo();
        string cmd;

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

            if (phone == "" || phone == null || pwd == "" || pwd == null)
                return null;
            else
            {
                cmd = "select phone,upwd,uname from users where phone = '" + phone + "' and upwd = '" + pwd + "'";

                if (users.Query(cmd).Rows[0]["phone"].ToString() == phone && users.Query(cmd).Rows[0]["upwd"].ToString() == pwd)
                {
                    return users.Query(cmd).Rows[0]["uname"].ToString();
                }
                else
                {
                    return null;
                }
            }
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
            if (phone == "" || phone == null || pwd == "" || pwd == null)
                return 2;
            else
            {
                if (!(PhoneExist(phone)))
                {
                    UsersInfo.upwd = pwd;
                    UsersInfo.phone = phone;
                    UsersInfo.uname = phone;
                    UsersInfo.address = " ";

                    if (users.Insert(UsersInfo) == -1)
                        return 2;

                    return 0;
                }
                else
                    return 1;
            }
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

            if (phone == "" || phone == null || Opwd == "" || Opwd == null || Npwd == "" || Npwd == null)
                return 2;
            else
            {
                cmd = "select upwd from users where phone = '" + phone + "'";

                if (users.Query(cmd).Rows[0]["pwd"].ToString() == Opwd)
                {
                    UsersInfo.phone = phone;
                    UsersInfo.upwd = Npwd;

                    if (users.Update(UsersInfo) == -1)
                        return 2;

                    return 0;
                }
                else
                    return 1;
            }
        }

        /// <summary>
        /// 设置密码
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="pwd">密码</param>
        /// <returns>true：成功；false：失败</returns>
        public bool SetPwd(string phone, string pwd)
        {
            if (phone == "" || phone == null || pwd == "" || pwd == null)
                return false;
            else
            {
                if (PhoneExist(phone))
                {
                    UsersInfo.phone = phone;
                    UsersInfo.upwd = pwd;

                    if (users.Update(UsersInfo) == -1)
                        return false;

                    return true;
                }
                else
                    return false;
            }
        }

        /// <summary>
        /// 手机号是否存在
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns>true：存在；false：不存在</returns>
        public bool PhoneExist(string phone)
        {
            cmd = "select phone from users where phone = '" + phone + "' ";

            if (phone == "" || phone == null)
                return false;
            else
            {
                if (users.Query(cmd).Rows[0]["phone"].ToString() == phone)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// 更改昵称
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="name">昵称</param>
        /// <returns>true：成功；false：失败</returns>
        public bool UpdateName(string phone, string name)
        {
            if (phone == null || phone == "" || name == "" || name == null)
                return false;
            else
            {
                UsersInfo.phone = phone;
                UsersInfo.uname = name;

                if (users.Update(UsersInfo) == -1)
                    return false;

                return true;
            }
        }

        /// <summary>
        /// 更新收货地址
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="address">地址</param>
        /// <returns>true：成功；false：失败</returns>
        public bool UpdateAddress(string phone, string address)
        {
            if (phone == null || phone == "" || address == null || address == "")
                return false;
            else
            {
                UsersInfo.phone = phone;
                UsersInfo.address = address;

                if (users.Update(UsersInfo) == -1)
                    return false;

                return true;
            }
        }

        /// <summary>
        /// 获取收货地址
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns>null：无收货地址：其他：收货地址</returns>
        public string GetAddress(string phone)
        {
            if (phone == null || phone == "")
                return null;
            else
            {
                cmd = "select address from users where phone = '" + phone + "'";
                return users.Query(cmd).Rows[0]["address"].ToString();
            }
        }

        /// <summary>
        /// 获取用户id
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns>-1：获取失败；其他：用户id</returns>
        public int GetId(string phone)
        {
            if (phone == null || phone == "")
                return -1;
            else
            {
                cmd = "select uid from users where phone = '" + phone + "'";
                return int.Parse(users.Query(cmd).Rows[0]["uid"].ToString());
            }
        }
    }
}
