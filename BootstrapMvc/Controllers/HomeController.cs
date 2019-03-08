using IBLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootstrapMvc.Controllers
{
    public class HomeController : Controller
    {
        private IUserInfoService UserInfoService = BLLContainer.Container.Resolve<IUserInfoService>();
        // GET: Home
        public ActionResult Index()
        {
            List<Base_UserInfo> list = UserInfoService.GetModels(p => true).ToList();
            ViewBag.Test = list[0].User_Name;
            return View(list);
        }
        public ActionResult Add(Base_UserInfo userInfo)
        {
            if (UserInfoService.Add(userInfo))
            {
                return Redirect("Index");
            }
            else
            {
                return Content("no");
            }
        }
        public ActionResult Update(Base_UserInfo staff)
        {
            if (UserInfoService.Update(staff))
            {
                return Redirect("Index");
            }
            else
            {
                return Content("no");
            }
        }
        public ActionResult Delete(string Id)
        {
            var userInfo = UserInfoService.GetModel(p => p.User_ID == Id);
            if (UserInfoService.Delete(userInfo))
            {
                return Redirect("Index");
            }
            else
            {
                return Content("no");
            }
        }
    }
}
