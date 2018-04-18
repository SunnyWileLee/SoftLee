using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Models
{
    public abstract class PropertyOwnerModel : BaseModel
    {
        public PropertyOwnerModel()
        {
            Properties = new List<PropertyValueModel> { };
        }

        public virtual List<PropertyValueModel> Properties { get; set; }
    }
}
