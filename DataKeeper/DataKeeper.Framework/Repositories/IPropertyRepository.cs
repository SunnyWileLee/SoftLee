using DataKeeper.Framework.Domain;
using DataKeeper.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories
{
    public interface IPropertyRepository
    {
        Guid Add<TProperty>(AddPropertyContext<TProperty> context) where TProperty : PropertyEntity;
    }
}
