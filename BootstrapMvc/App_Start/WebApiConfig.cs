using BootstrapMvc.UI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BootstrapMvc
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            //过滤器
            //统一添加Filter
            config.Filters.Add(new AuthFilterAttribute());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
