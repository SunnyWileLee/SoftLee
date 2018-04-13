using DataKeeper.Framework.Domain.Properties;
using DataKeeper.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories.Properties
{
    public interface IPropertyDeleteRepository : IBaseRepository
    {
        void Delete<TPropertyEntity>(DeletePropertyContext<TPropertyEntity> context) where TPropertyEntity : PropertyEntity;
    }
}
