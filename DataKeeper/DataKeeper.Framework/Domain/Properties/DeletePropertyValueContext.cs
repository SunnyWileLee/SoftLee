using DataKeeper.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Domain.Properties
{
    public class DeletePropertyValueContext<TPropertyValueEntity> : PropertyValueContext<TPropertyValueEntity>
        where TPropertyValueEntity : PropertyValueEntity
    {

    }
}
