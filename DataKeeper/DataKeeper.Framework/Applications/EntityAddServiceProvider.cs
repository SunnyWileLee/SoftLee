using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKeeper.Framework.Entities;

namespace DataKeeper.Framework.Applications
{
    public class EntityAddServiceProvider : IEntityAddServiceProvider
    {
        public IEntityAddService<TEntity> Provide<TEntity,TPropertyValueEntity>()
                where TEntity : UserEntity
        {
            throw new NotImplementedException();
        }
    }
}
