using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKeeper.Framework.Domain;
using DataKeeper.Framework.Domain.Properties;
using DataKeeper.Framework.Entities;

namespace DataKeeper.Framework.Repositories.Properties
{
    public class PropertyValueSetRepository : IPropertyValueSetRepository
    {
        public virtual void SetValues<TPropertyValueEntity>(SetPropertyValueContext<TPropertyValueEntity> context) 
            where TPropertyValueEntity : PropertyValueEntity
        {
            using (var db = context.ContextProvider.Provide())
            {
                var predicate = context.CreatePredicate();
                var values = db.Set<TPropertyValueEntity>()
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
                                        db.Set<TPropertyValueEntity>().Add(value);
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
