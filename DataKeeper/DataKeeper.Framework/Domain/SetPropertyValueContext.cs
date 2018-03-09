using DataKeeper.Framework.Entities;
using DataKeeper.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Domain
{
    public class SetPropertyValueContext<TPropertyValue> where TPropertyValue : PropertyValueEntity
    {
        public Guid UserId { get; set; }
        public Guid InstanceId { get; set; }
        public string KeyProperty { get; set; }
        public IDbContextProvider ContextProvider { get; set; }
        public IEnumerable<TPropertyValue> PropertyValues { get; set; }

        public Expression<Func<TPropertyValue, bool>> CreatePredicate()
        {
            var type = typeof(TPropertyValue);
            var parameter = Expression.Parameter(type, "value");
            var key = Expression.Property(parameter, KeyProperty);
            var value = Expression.Constant(InstanceId);
            var body = Expression.Equal(key, value);
            var predicate = Expression.Lambda<Func<TPropertyValue, bool>>(body, parameter);
            return predicate;
        }
    }
}
