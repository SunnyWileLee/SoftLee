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
    public class PropertyAddRepository : BaseRepository, IPropertyAddRepository
    {
        public virtual Guid Add<TProperty>(AddPropertyContext<TProperty> context) where TProperty : PropertyEntity
        {
            OnBefore(new RepositoryEventArgs { AccessDbContext = context });
            using (var db = context.ContextProvider.Provide())
            {
                if (context.Property.Id == Guid.Empty)
                {
                    context.Property.Id = Guid.NewGuid();
                }
                db.Set<TProperty>().Add(context.Property);
                var count = db.SaveChanges();
                OnComplete(new RepositoryEventArgs { AccessDbContext = context, Count = count });
                if (count > 0)
                {
                    OnSuccess(new RepositoryEventArgs { AccessDbContext = context, NewId = context.Property.Id });
                }
                else
                {
                    OnSuccess(new RepositoryEventArgs { AccessDbContext = context, ErrorMessage = "添加失败" });
                }
                return context.Property.Id;
            }
        }
    }
}
