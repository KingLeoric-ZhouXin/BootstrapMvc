using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using DAL;
using IDAL;
using Model;

namespace DALContainer
{
    public class Container
    {
        /// <summary>
        /// IOC 容器
        /// </summary>
        public static IContainer container = null;

        /// <summary>
        /// 获取 IDal 的实例化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            try
            {
                if (container == null)
                {
                    Initialise();
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("IOC实例化出错!" + ex.Message);
            }

            return container.Resolve<T>();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Initialise()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UserInfoDAL>().As<IUserInfoDAL>().InstancePerLifetimeScope();
            builder.RegisterType<UserTokenDAL>().As<IUserTokenDAL>().InstancePerLifetimeScope();
            container = builder.Build();
        }
    }
}
