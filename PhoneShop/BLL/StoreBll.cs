using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dal;
namespace BLL
{
    /// <summary>
    /// 商家Bll
    /// </summary>
    public class StoreBll
    {
        UsersDal users = new UsersDal();
        UsersInfo UsersInfo = new UsersInfo();
        string cmd;
        /// <summary>
        /// 商家登录
        /// </summary>
        /// <param name="sid">店家id</param>
        /// <param name="pwd">密码</param>
        /// <returns>null:登录失败；其他：品牌名</returns>
        public string Login(string sid, string pwd)
        {
            if (sid == "" || sid == null || pwd == "" || pwd == null)
                return null;
            else
            {
                cmd = "select sid,spwd,brand from store where sid = '" + sid + "'";

                if (users.Query(cmd).Rows[0]["sid"].ToString() == sid && users.Query(cmd).Rows[0]["pwd"].ToString() == pwd)
                {
                    return users.Query(cmd).Rows[0]["brand"].ToString();
                }
                else
                {
                    return null;
                }
            }            
        }
    }


}

