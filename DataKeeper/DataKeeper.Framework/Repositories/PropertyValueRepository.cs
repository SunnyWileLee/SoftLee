using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKeeper.Framework.Domain;
using DataKeeper.Framework.Entities;

namespace DataKeeper.Framework.Repositories
{
    public class PropertyValueRepository : IPropertyValueRepository
    {
        public virtual void SetValues<TPropertyValue>(SetPropertyValueContext<TPropertyValue> context) where TPropertyValue : PropertyValueEntity
        {
            using (var db = context.ContextProvider.Provide())
            {
                var predicate = context.CreatePredicate();
                var values = db.Set<TPropertyValue>()
                             .Where(s => s.UserId == context.UserId)
                             .Where(predicate)
                             .ToList();
                context.PropertyValues.ToList()
                       .ForEach(
                            value =>
                                {
                                    var current = values.FirstOrDefault(s => s.PropertyId == value.PropertyId);
                                    if (current == null)
                                    {
                                        db.Set<TPropertyValue>().Add(value);
                                    }
                                    else
                                    {
                                        current.Value = value.Value;
                                    }
                                });
                db.SaveChanges();
            }
        }
    }
}
