using DataKeeper.Framework.Domain;
using DataKeeper.Framework.Domain.Entities;
using DataKeeper.Framework.Entities;
using DataKeeper.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories.Entities
{
    public interface IEntityQueryRepository
    {
        PageCollection<TEntity> Page<TEntity>(QueryEntityPageContext<TEntity> context) where TEntity : UserEntity;
        List<TEntity> Query<TEntity>(QueryEntityContext<TEntity> context) where TEntity : UserEntity;
    }
}
