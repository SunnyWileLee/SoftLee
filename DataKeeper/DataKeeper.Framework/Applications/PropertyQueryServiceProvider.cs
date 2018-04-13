using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using DataKeeper.Framework.Domain;
using DataKeeper.Framework.Entities;

namespace DataKeeper.Framework.Applications
{
    class PropertyQueryServiceProvider : IPropertyQueryServiceProvider
    {
        public IPropertyQueryService<TPropertyEntity> Provide<TPropertyEntity>()
            where TPropertyEntity : PropertyEntity
        {
            return ObjectContainers.Current.Resolve<IPropertyQueryService<TPropertyEntity>>();
        }
    }
}
