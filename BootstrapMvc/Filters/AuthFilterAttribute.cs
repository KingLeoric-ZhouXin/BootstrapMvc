using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BootstrapMvc.UI.Filters
{
    public class AuthFilterAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);

            if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any())
            {
                return;
            }
            else
            {
                var authorization = actionContext.Request.Headers.Authorization;
                if (authorization == null || string.IsNullOrEmpty(authorization.Parameter))
                {
                    ResponseModel<string> requestModel = new ResponseModel<string>();
                    requestModel.success = false;
                    requestModel.msg = "登录已经超时，请重新登录";

                    var response = actionContext.Response = actionContext.Response ?? new HttpResponseMessage();

                    response.StatusCode = HttpStatusCode.Forbidden;

                    response.Content = new StringContent(JsonConvert.SerializeObject(requestModel, Formatting.None), Encoding.UTF8, "application/json");
                    return;
                }
            }
        }
    }
}