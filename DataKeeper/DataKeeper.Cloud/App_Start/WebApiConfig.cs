using DataKeeper.Framework;
using DataKeeper.Framework.Models;
using DataKeeper.Framework.Webapi;
using DataKeeper.Infrustructure;
using DataKeeper.Ums.User;
using DataKeeper.Ums.User.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace DataKeeper.Cloud
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new ParasCheckAttribute());

            AutofacConfig.Config(config, typeof(WebApiApplication).Assembly,
                                          new List<Assembly>
                                          {
                                              typeof(IAutofacFramework).Assembly,
                                              typeof(IAutofacInfrustructure).Assembly,
                                              typeof(IAutofacUser).Assembly
                                          });

            AutoMapperConfig.Config(config.DependencyResolver.GetService(typeof(IMapperProfileProvider)) as IMapperProfileProvider);

            var accountQueryService = config.DependencyResolver.GetService(typeof(IAccountQueryService)) as IAccountQueryService;
            config.MessageHandlers.Add(new DataKeeperUserMessageHandler
                                        {
                                            GetUserIdAction = s =>
                                            {
                                                return accountQueryService.GetByToken(s)?.Id ?? Guid.Empty;
                                            }
                                        });
        }
    }
}
