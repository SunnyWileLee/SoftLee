using DataKeeper.Framework.Entities;
using DataKeeper.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Domain.Properties
{
    public class QueryPropertyValueContext<TPropertyValueEntity> : AccessDbContext
        where TPropertyValueEntity : PropertyValueEntity
    {
        public Guid Key { get; set; }
        public IPropertyValueKeyProvider PropertyValueKeyProvider { get; set; }

        public Expression<Func<TPropertyValueEntity, bool>> CreatePredicate()
        {
            var type = typeof(TPropertyValueEntity);
            var parameter = Expression.Parameter(type, "value");
            var key = Expression.Property(parameter, PropertyValueKeyProvider.Provide<TPropertyValueEntity>());
            var value = Expression.Constant(Key);
            var body = Expression.Equal(key, value);
            var predicate = Expression.Lambda<Func<TPropertyValueEntity, bool>>(body, parameter);
            return predicate;
        }
    }
}
