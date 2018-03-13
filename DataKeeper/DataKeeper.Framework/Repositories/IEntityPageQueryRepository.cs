using DataKeeper.Framework.Domain;
using DataKeeper.Framework.Entities;
using DataKeeper.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories
{
    public interface IEntityPageQueryRepository
    {
        PageCollection<TEntity> Page<TEntity>(EntityPageQueryContext<TEntity> context) where TEntity : UserEntity;
    }
}
