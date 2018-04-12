using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKeeper.Framework.Domain;
using DataKeeper.Framework.Entities;

namespace DataKeeper.Framework.Repositories
{
    class EntityAddRepository : BaseRepository, IEntityAddRepository
    {
        public Guid Add<TEntity>(AddEntityContext<TEntity> context) where TEntity : UserEntity
        {
            var args = new RepositoryEventArgs
            {
                AccessDbContext = context
            };
            base.OnBefore(args);
            using (var db = context.ContextProvider.Provide())
            {
                var entities = db.Set<TEntity>();
                var entity = context.Entity;
                entity.UserId = context.UserId;
                entities.Add(entity);
                var count = db.SaveChanges();
                base.OnComplete(args);
                var success = count > 0;
                if (success)
                {
                    args.NewId = entity.Id;
                    OnSuccess(args);
                }
                else
                {
                    OnFail(args);
                }
                return success ? entity.Id : Guid.Empty;
            }
        }
    }
}
