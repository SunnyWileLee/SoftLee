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
    public class PropertyQueryRepository : BaseRepository, IPropertyQueryRepository
    {
        public virtual TProperty First<TProperty>(QueryPropertyContext<TProperty> context) where TProperty : PropertyEntity
        {
            using (var db = context.ContextProvider.Provide())
            {
                return db.Set<TProperty>()
                         .Where(s => s.UserId == context.UserId)
                         .Where(context.Predicate)
                         .FirstOrDefault();
            }
        }

        public virtual List<TProperty> Query<TProperty>(QueryPropertyContext<TProperty> context) where TProperty : PropertyEntity
        {
            using (var db = context.ContextProvider.Provide())
            {
                return db.Set<TProperty>()
                         .Where(s => s.UserId == context.UserId)
                         .Where(context.Predicate)
                         .ToList();
            }
        }
    }
}
