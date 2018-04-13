using DataKeeper.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Domain.Properties
{
    public class DeletePropertyValueContext<TPropertyValueEntity> : AccessDbContext
        where TPropertyValueEntity : PropertyValueEntity
    {
        public Guid InstanceId { get; set; }
        public string KeyProperty { get; set; }

        public Expression<Func<TPropertyValueEntity, bool>> CreatePredicate()
        {
            var type = typeof(TPropertyValueEntity);
            var parameter = Expression.Parameter(type, "value");
            var key = Expression.Property(parameter, KeyProperty);
            var value = Expression.Constant(InstanceId);
            var body = Expression.Equal(key, value);
            var predicate = Expression.Lambda<Func<TPropertyValueEntity, bool>>(body, parameter);
            return predicate;
        }
    }
}
