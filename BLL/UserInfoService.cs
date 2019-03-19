using IDAL;
using Model;
using Utils;
using System;
using System.Linq;
using System.Linq.Expressions;
using DAL;

namespace BLL
{
    public class UserInfoService
    {
        private IUserInfoDAL dal = new UserInfoDAL();
        private IUserTokenDAL tokenDal = new UserTokenDAL();

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName">账号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public ResponseModel<string> Login(string userName, string password)
        {

            string md5Pwd = EncyptHelper.MD5(password);

            var model = dal.GetModel(q => q.User_Account == userName && q.User_Pwd == md5Pwd);

            ResponseModel<string> response = new ResponseModel<string>();

            if (model != null)
            {

                var token = tokenDal.GetModel(p => p.User_ID == model.User_ID);

                if (token != null)
                {
                    token.OverdueDate = DateTime.Now.AddHours(2);
                    tokenDal.Update(token);

                    if (tokenDal.SaveChanges())
                    {

                    }
                }
                else
                {
                    token.OverdueDate = DateTime.Now.AddHours(2);
                    //token.Token
                    tokenDal.Update(token);
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
    }
}
