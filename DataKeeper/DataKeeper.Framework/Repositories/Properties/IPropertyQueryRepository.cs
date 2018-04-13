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
    public interface IPropertyQueryRepository
    {
        List<TProperty> Query<TProperty>(QueryPropertyContext<TProperty> context) where TProperty : PropertyEntity;
        TProperty First<TProperty>(QueryPropertyContext<TProperty> context) where TProperty : PropertyEntity;
    }
}
