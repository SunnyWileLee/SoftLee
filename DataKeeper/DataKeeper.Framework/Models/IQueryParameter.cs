using DataKeeper.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Models
{
    public interface IQueryParameter<TEntity> where TEntity : UserEntity
    {
        Expression<Func<TEntity, bool>> CreatePredicate();
    }
}
