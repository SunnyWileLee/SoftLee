using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKeeper.Framework.Domain;
using DataKeeper.Framework.Entities;

namespace DataKeeper.Framework.Repositories
{
    public class PropertyQueryRepository : IPropertyQueryRepository
    {
        public virtual List<TProperty> Add<TProperty>(QueryPropertyContext<TProperty> context) where TProperty : PropertyEntity
        {
            using (var db = context.ContextProvider.Provide())
            {
                return db.Set<TProperty>().Where(s => s.UserId == context.UserId).ToList();
            }
        }
    }
}
