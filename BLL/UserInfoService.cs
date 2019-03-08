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

namespace BLL
{
    public class UserInfoService : BaseService<Base_UserInfo>, IUserInfoService
    {

        private IUserInfoDAL UserInfoDAL = Container.Resolve<IUserInfoDAL>();

        public override void SetDal()
        {
            Dal = UserInfoDAL;
        }
    }
}
