using DataKeeper.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Applications
{
    public interface IEntityAddService<TEntity> where TEntity : UserEntity
    {
        Guid Add<TModel>(TModel model);
    }
}
