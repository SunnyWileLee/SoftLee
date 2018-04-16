using DataKeeper.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Models
{
    public abstract class QueryParameter<TEntity> : IQueryParameter<TEntity>
        where TEntity : UserEntity
    {
        public virtual Expression<Func<TEntity, bool>> CreatePredicate()
        {
            return s => true;
        }
    }
}
