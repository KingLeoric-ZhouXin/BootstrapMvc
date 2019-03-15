using DAL;
using IBLL;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALContainer;
using Utils;

namespace BLL
{
    public class UserInfoService : BaseService<Base_UserInfo>, IUserInfoService
    {

        private IUserInfoDAL UserInfoDAL = Container.Resolve<IUserInfoDAL>();

        public override void SetDal()
        {
            Dal = UserInfoDAL;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName">账号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public ResponseModel<string> Login(string userName, string password)
        {

            string md5Pwd = EncyptHelper.MD5(password);

            var model = this.GetModel(q => q.User_Account == userName && q.User_Pwd == md5Pwd);

            ResponseModel<string> response = new ResponseModel<string>();


            if (model != null)
            {
                response.success = true;
                response.msg = "登录成功";
                response.data = "{}";
                return response;
            }
            else
            {
                response.success = false;
                response.msg = "账号密码错误";
                response.data = "{}";
                return response;
            }
        }
    }
}
