using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKeeper.Framework.Domain.Properties;
using DataKeeper.Framework.Entities;

namespace DataKeeper.Framework.Repositories.Properties
{
    public class PropertyValueDeleteRepository : BaseRepository, IPropertyValueDeleteRepository
    {
        public void Delete<TPropertyValueEntity>(DeletePropertyValueContext<TPropertyValueEntity> context)
            where TPropertyValueEntity : PropertyValueEntity
        {
            using (var db = context.ContextProvider.Provide())
            {
                var predicate = context.CreatePredicate();
                var values = db.Set<TPropertyValueEntity>()
                             .Where(s => s.UserId == context.UserId)
                             .Where(predicate)
                             .ToList();
                OnBefore(new RepositoryEventArgs
                {
                    AccessDbContext = context,
                    Instances = values
                });
                if (context.IsCancel)
                {
                    return;
                }
                if (values.Any())
                {
                    db.Set<TPropertyValueEntity>().RemoveRange(values);
                }
                var count = db.SaveChanges();
                OnComplete(new RepositoryEventArgs
                {
                    AccessDbContext = context,
                    Count = count,
                    Instances = values
                });
                if (count > 0)
                {
                    OnSuccess(new RepositoryEventArgs
                    {
                        AccessDbContext = context,
                        Count = count,
                        Instances = values
                    });
                }
                else
                {
                    OnFail(new RepositoryEventArgs
                    {
                        AccessDbContext = context,
                        Count = count,
                        Instances = values
                    });
                }
            }
        }
    }
}
