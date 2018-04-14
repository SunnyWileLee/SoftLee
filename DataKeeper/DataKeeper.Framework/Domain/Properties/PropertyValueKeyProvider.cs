using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Domain.Properties
{
    public class PropertyValueKeyProvider : CachedPropertyValueKeyProvider
    {
        protected override string ProvideMethod(Type type)
        {
            var attr = type.GetCustomAttribute<PropertyValueDescriptionAttribute>();
            if (attr == null)
            {

            }
            return attr.InstanceKey;
        }

        private string GetDefaultKey(Type type)
        {
            if (!type.Name.EndsWith("PropertyValueEntity"))
            {
                throw new ArgumentOutOfRangeException("PropertyValueKeyProvider=>GetDefaultKey");
            }
            return type.Name.Replace("PropertyValueEntity", string.Empty);
        }
    }
}
