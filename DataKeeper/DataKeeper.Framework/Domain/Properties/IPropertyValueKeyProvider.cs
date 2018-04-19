using DataKeeper.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Domain.Properties
{
    public interface IPropertyValueKeyProvider
    {
        string Provide<TPropertyValueEntity>() where TPropertyValueEntity : PropertyValueEntity;
        string Provide(Type type);
    }
}
