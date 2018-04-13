using DataKeeper.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Applications
{
    public interface IPropertyQueryService<TPropertyEntity> 
        where TPropertyEntity : PropertyEntity
    {
        List<TPropertyModel> Query<TPropertyModel>();
        TPropertyModel First<TPropertyModel>(Guid id);
    }
}
