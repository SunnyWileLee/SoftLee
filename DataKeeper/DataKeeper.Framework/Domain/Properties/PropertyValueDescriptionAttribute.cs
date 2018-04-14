using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Domain.Properties
{
    public class PropertyValueDescriptionAttribute : Attribute
    {
        public PropertyValueDescriptionAttribute(string instanceKey)
        {
            InstanceKey = instanceKey;
        }

        public string InstanceKey { get; private set; }
    }
}
