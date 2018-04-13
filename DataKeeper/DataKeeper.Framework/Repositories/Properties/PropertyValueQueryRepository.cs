using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataKeeper.Framework.Domain;
using DataKeeper.Framework.Domain.Properties;
using DataKeeper.Framework.Entities;

namespace DataKeeper.Framework.Repositories.Properties
{
    public class PropertyValueQueryRepository : IPropertyValueQueryRepository
    {
        public IEnumerable<IGrouping<Guid, TPropertyValue>> Grouping<TPropertyValue>(GroupPropertyValueContext<TPropertyValue> context) where TPropertyValue : PropertyValueEntity
        {
            using (var db = context.ContextProvider.Provide())
            {
                var values = db.Set<TPropertyValue>()
                               .Where(s => s.UserId == context.UserId)
                               .Where(context.CreatePredicate())
                               .ToList();
                return values.GroupBy(context.GroupKey().Compile());
            }
        }

        public IEnumerable<TPropertyValue> Query<TPropertyValue>(QueryPropertyValueContext<TPropertyValue> context) where TPropertyValue : PropertyValueEntity
        {
            using (var db = context.ContextProvider.Provide())
            {
                var values = db.Set<TPropertyValue>()
                               .Where(s => s.UserId == context.UserId)
                               .Where(context.CreatePredicate())
                               .ToList();
                return values;
            }
        }
    }
}
