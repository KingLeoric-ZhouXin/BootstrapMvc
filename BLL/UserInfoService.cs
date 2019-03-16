using IBLL;
using IDAL;
using Model;
using DALContainer;
using Utils;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BLL
{
    public class UserInfoService : BaseService<Base_UserInfo>, IUserInfoService
    {

        private IUserInfoDAL UserInfoDAL = Container.Resolve<IUserInfoDAL>();
        private IUserTokenService UserTokenService = Container.Resolve<IUserTokenService>();

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

                var token = UserTokenService.GetModel(p => p.User_ID == model.User_ID);

                if (token != null)
                {

                }

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

        public new IQueryable<Base_UserInfo> GetModels<type>(Expression<Func<Base_UserInfo, bool>> whereLambda)
        {
            throw new NotImplementedException();
        }
    }
}
