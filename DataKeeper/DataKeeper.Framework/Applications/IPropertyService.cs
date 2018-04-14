using DataKeeper.Framework.Entities;
using DataKeeper.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Applications
{
    public interface IPropertyService<TPropertyEntity>
        where TPropertyEntity : PropertyEntity
    {
        Guid Add<TPropertyModel>(TPropertyModel model) where TPropertyModel : PropertyModel;
        void Update<TPropertyModel>(TPropertyModel model) where TPropertyModel : PropertyModel;
        void Delete(Guid id);
    }
}
