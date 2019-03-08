using IBLL;
using IDAL;
using Model;
using DALContainer;
using Utils;

namespace BLL
{
    public class UserInfoService : BaseService<Base_UserInfo>, IUserInfoService
    {

        private IUserInfoDAL UserInfoDAL = Container.Resolve<IUserInfoDAL>();

        public Base_UserInfo Login(string userName, string password)
        {
            string strMD5 = EncyptHelper.MD5(password);
            var model = Dal.GetModel(s => s.User_Account == userName && s.User_Pwd == strMD5);
            return model;
        }

        public override void SetDal()
        {
            Dal = UserInfoDAL;
        }
    }
}
