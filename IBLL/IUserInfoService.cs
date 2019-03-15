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
        ResponseModel<string> Login(string userName, string password);
    }
}
