using Autofac;
using DataKeeper.Framework.Applications;
using DataKeeper.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework
{
    public static class AutofacRegister
    {
        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(RepositoryProvider<>))
                   .As(typeof(IRepositoryProvider<>))
                   .InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(PropertyDeleteService<,>))
                   .As(typeof(IPropertyDeleteService<,>))
                   .InstancePerLifetimeScope();
        }
    }
}
