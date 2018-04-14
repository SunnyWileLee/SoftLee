using DataKeeper.Framework.Entities;
using DataKeeper.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Domain.Properties
{
    public class SetPropertyValueContext<TPropertyValueEntity> : PropertyValueContext<TPropertyValueEntity>
        where TPropertyValueEntity : PropertyValueEntity
    {
        public IEnumerable<TPropertyValueEntity> PropertyValues { get; set; }
    }
}
