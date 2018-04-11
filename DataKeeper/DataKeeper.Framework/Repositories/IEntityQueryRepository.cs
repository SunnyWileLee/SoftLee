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
    public interface IEntityQueryRepository
    {
        PageCollection<TEntity> Page<TEntity>(QueryEntityPageContext<TEntity> context) where TEntity : UserEntity;
        List<TEntity> GetList<TEntity>(QueryEntityContext<TEntity> context) where TEntity : UserEntity;
    }
}
