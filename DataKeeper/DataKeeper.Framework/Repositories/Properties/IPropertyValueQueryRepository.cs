using DataKeeper.Framework.Domain;
using DataKeeper.Framework.Domain.Properties;
using DataKeeper.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories.Properties
{
    public interface IPropertyValueQueryRepository : IBaseRepository
    {
        IEnumerable<IGrouping<Guid, TPropertyValueEntity>> Grouping<TPropertyValueEntity>(GroupPropertyValueContext<TPropertyValueEntity> context) where TPropertyValueEntity : PropertyValueEntity;
        IEnumerable<TPropertyValueEntity> Query<TPropertyValueEntity>(QueryPropertyValueContext<TPropertyValueEntity> context) where TPropertyValueEntity : PropertyValueEntity;
    }
}
