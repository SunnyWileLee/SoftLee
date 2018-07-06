using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DkmsCore.Avengers;
using DkmsCore.Avengers.Configs;
using DkmsCore.Stark;
using DkmsCore.StarLord;
using DkmsCore.Thanos.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DkmsCore.Thanos
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddOptions().Configure<AppSettingOptions>(Configuration.GetSection(nameof(AppSettingOptions)));

            // Add Autofac
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterAssemblyTypes(typeof(IAutofacStarLord).Assembly).AsImplementedInterfaces();
            containerBuilder.RegisterAssemblyTypes(typeof(IAutofacThanos).Assembly).AsImplementedInterfaces();
            containerBuilder.RegisterAssemblyTypes(typeof(IAutofacAvengers).Assembly).AsImplementedInterfaces();
            containerBuilder.RegisterAssemblyTypes(typeof(IAutofacStark).Assembly).AsImplementedInterfaces();
            containerBuilder.Populate(services);
            var container = containerBuilder.Build();

            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(env.ContentRootPath)
                          .AddJsonFile("appsetting.json", optional: true, reloadOnChange: true)
                          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                          .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            var gateway = app.ApplicationServices.GetService<IGatewayRouter>();
            app.UseRouter(gateway);
            app.UseCors("AllowAllOrigin");
        }
    }
}
