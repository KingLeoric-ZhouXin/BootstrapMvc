using IBLL;
using IDAL;
using Model;
using DALContainer;
using Utils;

namespace BLL
{
    public class UserTokenService : BaseService<Base_UserToken>, IUserTokenService
    {

        private IUserTokenDAL UserInfoDAL = Container.Resolve<IUserTokenDAL>();

        public override void SetDal()
        {
            Dal = UserInfoDAL;
        }
    }
}
