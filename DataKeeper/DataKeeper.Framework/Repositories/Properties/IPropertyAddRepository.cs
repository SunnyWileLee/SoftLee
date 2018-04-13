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
    public interface IPropertyAddRepository : IBaseRepository
    {
        Guid Add<TProperty>(AddPropertyContext<TProperty> context) where TProperty : PropertyEntity;
    }
}
