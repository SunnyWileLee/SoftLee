using DataKeeper.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Applications
{
    public interface IEntityAddServiceProvider
    {
        IEntityAddService<TEntity, TPropertyValueEntity> Provide<TEntity, TPropertyValueEntity>()
            where TEntity : UserEntity
            where TPropertyValueEntity : PropertyValueEntity;
    }
}
