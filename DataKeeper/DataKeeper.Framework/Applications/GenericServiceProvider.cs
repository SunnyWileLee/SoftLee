using Autofac;
using DataKeeper.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Applications
{
    class GenericServiceProvider : IGenericServiceProvider
    {
        public TService Provide<TService>()
        {
            return ObjectContainers.Current.Resolve<TService>();
        }
    }
}
