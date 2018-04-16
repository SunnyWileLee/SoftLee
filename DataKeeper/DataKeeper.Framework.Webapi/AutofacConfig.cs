using Autofac;
using Autofac.Integration.WebApi;
using DataKeeper.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace DataKeeper.Framework.Webapi
{
    public static class AutofacConfig
    {
        public static void Config(HttpConfiguration config, Assembly webapiAssembly, IEnumerable<Assembly> assemblies)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(webapiAssembly);
            builder.RegisterAssemblyTypes(webapiAssembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(assemblies.ToArray()).AsImplementedInterfaces();
            AutofacRegister.Register(builder);
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            ObjectContainers.Current = container;
        }
    }
}
