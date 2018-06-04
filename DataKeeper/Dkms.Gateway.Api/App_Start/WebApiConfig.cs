using Autofac;
using Autofac.Integration.WebApi;
using Dkms.Eureka;
using Dkms.Gateway.Api.Frameworks;
using Dkms.Hystrix;
using Dkms.Repository;
using Dkms.Route;
using Dkms.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Dkms.Gateway.Api
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
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.Add("transfer", new TransferHttpRoute { });

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(typeof(WebApiConfig).Assembly);
            builder.RegisterAssemblyTypes(typeof(WebApiConfig).Assembly,
                                            typeof(IAutofacScanDkmsTools).Assembly,
                                            typeof(IAutofacScanDkmsRoute).Assembly,
                                            typeof(IAutofacScanDkmsRepository).Assembly,
                                            typeof(IAutofacScanDkmsHystrix).Assembly,
                                            typeof(IAutofacScanDkmsGateway).Assembly,
                                            typeof(IAutofacScanDkmsEureka).Assembly
                                            ).AsImplementedInterfaces();
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            //GlobalConfiguration.Configuration.MessageHandlers.Add(
            //                            new TransferMessageHandler());
        }
    }
}
