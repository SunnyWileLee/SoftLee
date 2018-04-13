using DataKeeper.Framework.Domain;
using DataKeeper.Framework.Domain.Entities;
using DataKeeper.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories.Entities
{
    public interface IEntityAddRepository : IBaseRepository
    {
        Guid Add<TEntity>(AddEntityContext<TEntity> context) where TEntity : UserEntity;
    }
}
