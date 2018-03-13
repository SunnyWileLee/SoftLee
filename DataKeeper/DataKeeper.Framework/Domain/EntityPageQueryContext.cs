using DataKeeper.Framework.Entities;
using DataKeeper.Framework.Models;
using DataKeeper.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Domain
{
    public class EntityPageQueryContext<TEntity> where TEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public Expression<Func<TEntity, bool>> Predicate;
        public IDbContextProvider ContextProvider { get; set; }
        public PageQueryParas PageQueryParas { get; set; }
    }
}
