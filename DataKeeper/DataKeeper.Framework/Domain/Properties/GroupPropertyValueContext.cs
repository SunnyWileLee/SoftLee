using DataKeeper.Framework.Entities;
using DataKeeper.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Domain.Properties
{
    public class GroupPropertyValueContext<TPropertyValueEntity> : AccessDbContext
        where TPropertyValueEntity:PropertyValueEntity
    {
        private static MethodInfo containsMethod;
        private static object containsMethodLock = new object { };

        public IEnumerable<Guid> Keys { get; set; }
        public IPropertyValueKeyProvider PropertyValueKeyProvider { get; set; }

        public Expression<Func<TPropertyValueEntity, bool>> CreatePredicate()
        {
            var contains = GetContainsMethod();

            var type = typeof(TPropertyValueEntity);
            var parameter = Expression.Parameter(type, "value");
            var key = Expression.Property(parameter, PropertyValueKeyProvider.Provide<TPropertyValueEntity>());

            var arguments = new List<Expression> {
                Expression.Constant(Keys),
                key
            };
            var call = Expression.Call(contains, arguments);
            var predicate = Expression.Lambda<Func<TPropertyValueEntity, bool>>(call, parameter);
            return predicate;
        }

        public Expression<Func<TPropertyValueEntity, Guid>> GroupKey()
        {
            var type = typeof(TPropertyValueEntity);
            var parameter = Expression.Parameter(type, "value");
            var key = Expression.Property(parameter, PropertyValueKeyProvider.Provide<TPropertyValueEntity>());

            var keySelector = Expression.Lambda<Func<TPropertyValueEntity, Guid>>(key, parameter);
            return keySelector;
        }

        private MethodInfo GetContainsMethod()
        {
            if (containsMethod != null)
            {
                return containsMethod;
            }
            lock (containsMethodLock)
            {
                if (containsMethod != null)
                {
                    return containsMethod;
                }
                var contains = typeof(Enumerable).GetMethods().First(s => s.Name == "Contains" && s.GetParameters().Count() == 2).GetGenericMethodDefinition();
                containsMethod = contains.MakeGenericMethod(typeof(Guid));
                return containsMethod;
            }
        }
    }
}
