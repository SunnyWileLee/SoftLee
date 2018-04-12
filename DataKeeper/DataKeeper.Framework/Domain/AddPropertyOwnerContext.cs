using DataKeeper.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Domain
{
    public class AddPropertyOwnerContext<TEntity, TPropertyValueEntity> : AddEntityContext<TEntity>
        where TEntity : UserEntity
        where TPropertyValueEntity : PropertyValueEntity
    {
        public IEnumerable<TPropertyValueEntity> Values { get; set; }
    }
}
