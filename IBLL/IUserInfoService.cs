using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IBLL
{
    public interface IUserInfoService : IBaseService<Base_UserInfo>
    {
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        Base_UserInfo Login(string userName, string password);
    }
}
