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
    public class EntityAddServiceProvider : IEntityAddServiceProvider
    {
        public IEntityAddService<TEntity, TPropertyValueEntity> Provide<TEntity, TPropertyValueEntity>()
                where TEntity : UserEntity
                where TPropertyValueEntity : PropertyValueEntity
        {
            return ObjectContainers.Current.Resolve<IEntityAddService<TEntity, TPropertyValueEntity>>();
        }
    }
}
