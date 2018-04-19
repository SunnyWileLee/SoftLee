using DataKeeper.Framework.Entities;
using DataKeeper.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Applications
{
    public interface IEntityQueryService<TEntity, TPropertyValueEntity>
        where TEntity : UserEntity
        where TPropertyValueEntity : PropertyValueEntity
    {
        PageCollection<TModel> Page<TModel>(PageQueryParameter<TEntity> parameter) where TModel : PropertyOwnerModel<TPropertyValueEntity>;
        List<TModel> Query<TModel>(QueryParameter<TEntity> parameter);
    }
}
