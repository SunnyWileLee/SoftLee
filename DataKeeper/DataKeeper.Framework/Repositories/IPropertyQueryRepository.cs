using DataKeeper.Framework.Domain;
using DataKeeper.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories
{
    public interface IPropertyQueryRepository
    {
        List<TProperty> Add<TProperty>(QueryPropertyContext<TProperty> context) where TProperty : PropertyEntity;
    }
}
