using DataKeeper.Framework.Domain;
using DataKeeper.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories
{
    public interface IPropertyValueQueryRepository
    {
        IEnumerable<IGrouping<Guid, TPropertyValue>> Grouping<TPropertyValue>(GroupPropertyValueContext<TPropertyValue> context) where TPropertyValue : PropertyValueEntity;
        IEnumerable<TPropertyValue> Query<TPropertyValue>(QueryPropertyValueContext<TPropertyValue> context) where TPropertyValue : PropertyValueEntity;
    }
}
