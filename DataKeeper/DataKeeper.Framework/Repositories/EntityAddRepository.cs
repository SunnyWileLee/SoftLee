using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKeeper.Framework.Domain;
using DataKeeper.Framework.Entities;

namespace DataKeeper.Framework.Repositories
{
    class EntityAddRepository : IEntityAddRepository
    {
        public Guid Add<TEntity>(AddEntityContext<TEntity> context) where TEntity : UserEntity
        {
            using (var db = context.ContextProvider.Provide())
            {
                var entities = db.Set<TEntity>();
                var entity = context.Entity;
                entity.UserId = context.UserId;
                entities.Add(entity);
                var count = db.SaveChanges();
                return count > 0 ? entity.Id : Guid.Empty;
            }
        }
    }
}
