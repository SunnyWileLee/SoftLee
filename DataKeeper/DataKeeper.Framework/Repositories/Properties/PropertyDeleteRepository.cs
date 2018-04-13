using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKeeper.Framework.Domain.Properties;
using DataKeeper.Framework.Entities;

namespace DataKeeper.Framework.Repositories.Properties
{
    public class PropertyDeleteRepository : BaseRepository, IPropertyDeleteRepository
    {
        public void Delete<TPropertyEntity>(DeletePropertyContext<TPropertyEntity> context) where TPropertyEntity : PropertyEntity
        {
            using (var db = context.ContextProvider.Provide())
            {
                var property = db.Set<TPropertyEntity>()
                                 .Where(s => s.UserId == context.UserId)
                                 .FirstOrDefault(s => s.Id == context.Id);
                OnBefore(new RepositoryEventArgs { AccessDbContext = context, Instance = property });
                if (context.IsCancel)
                {
                    return;
                }
                db.Set<TPropertyEntity>().Remove(property);
                var count = db.SaveChanges();
                OnComplete(new RepositoryEventArgs { AccessDbContext = context, Count = count });
                if (count > 0)
                {
                    OnSuccess(new RepositoryEventArgs { AccessDbContext = context, EntityId = context.Id });
                }
                else
                {
                    OnSuccess(new RepositoryEventArgs { AccessDbContext = context, ErrorMessage = "添加失败" });
                }
            }
        }
    }
}
