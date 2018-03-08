using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKeeper.Framework.Domain;
using DataKeeper.Framework.Entities;

namespace DataKeeper.Framework.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        public virtual Guid Add<TProperty>(AddPropertyContext<TProperty> context) where TProperty : PropertyEntity
        {
            using (var db = context.ContextProvider.Provide())
            {
                if (context.Property.Id == Guid.Empty)
                {
                    context.Property.Id = Guid.NewGuid();
                }
                db.Set<TProperty>().Add(context.Property);
                db.SaveChanges();
                return context.Property.Id;
            }
        }
    }
}
