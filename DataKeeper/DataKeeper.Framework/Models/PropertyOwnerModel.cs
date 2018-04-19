using DataKeeper.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Models
{
    public abstract class PropertyOwnerModel<TPropertyValueEntity> : BaseModel
        where TPropertyValueEntity : PropertyValueEntity
    {
        public PropertyOwnerModel()
        {
            Properties = new List<TPropertyValueEntity> { };
        }

        public virtual List<TPropertyValueEntity> Properties { get; set; }
    }
}
