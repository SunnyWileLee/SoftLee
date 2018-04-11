using DataKeeper.Framework.Entities;
using DataKeeper.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Domain
{
    public class QueryEntityContext<TEntity> : AccessDbContext
        where TEntity : UserEntity
    {
        public Expression<Func<TEntity, bool>> Predicate;
    }
}
