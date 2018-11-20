using Autofac;
using Autofac.Extensions.DependencyInjection;
using DkmsCore.Persistence;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DkmsCore.Infrustructure.Webs
{
    public static class DkmsStartups
    {
        public static IServiceProvider ConfigureServices(IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddMvc(options =>
                                {
                                    options.Filters.Add(typeof(DkmsResultMiddleWare));
                                    options.RespectBrowserAcceptHeader = true;
                                });
            services.AddCors();

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterAssemblyTypes(assemblies).AsImplementedInterfaces();
            containerBuilder.RegisterAssemblyTypes(typeof(IDkmsCoreInfrustructureAutofac).Assembly).AsImplementedInterfaces();
            containerBuilder.RegisterAssemblyTypes(typeof(IDkmsCorePersisteceAutofac).Assembly).AsImplementedInterfaces();
            containerBuilder.Populate(services);
            var container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
        }
    }
}
