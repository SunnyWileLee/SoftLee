using DataKeeper.Framework.Domain;
using DataKeeper.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories
{
    public interface IEntityAddRepository : IBaseRepository
    {
        Guid Add<TEntity>(AddEntityContext<TEntity> context) where TEntity : UserEntity;
    }
}
