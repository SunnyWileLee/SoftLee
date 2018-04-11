using DataKeeper.Framework.Entities;
using DataKeeper.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Domain
{
    public class GroupPropertyValueContext<TPropertyValue> : AccessDbContext
        where TPropertyValue:PropertyValueEntity
    {
        private static MethodInfo containsMethod;
        private static object containsMethodLock = new object { };

        public IEnumerable<Guid> Keys { get; set; } 
        public string KeyProperty { get; set; }

        public Expression<Func<TPropertyValue, bool>> CreatePredicate()
        {
            var contains = GetContainsMethod();

            var type = typeof(TPropertyValue);
            var parameter = Expression.Parameter(type, "value");
            var key = Expression.Property(parameter, KeyProperty);

            var arguments = new List<Expression> {
                Expression.Constant(Keys),
                key
            };
            var call = Expression.Call(contains, arguments);
            var predicate = Expression.Lambda<Func<TPropertyValue, bool>>(call, parameter);
            return predicate;
        }

        public Expression<Func<TPropertyValue, Guid>> GroupKey()
        {
            var type = typeof(TPropertyValue);
            var parameter = Expression.Parameter(type, "value");
            var key = Expression.Property(parameter, KeyProperty);

            var keySelector = Expression.Lambda<Func<TPropertyValue, Guid>>(key, parameter);
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
