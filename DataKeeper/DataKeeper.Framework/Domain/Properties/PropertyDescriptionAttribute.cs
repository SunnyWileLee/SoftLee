using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Domain.Properties
{
    public class PropertyDescriptionAttribute : Attribute
    {
        public Type PropertyValueType { get; set; }
    }
}
