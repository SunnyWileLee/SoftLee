using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Domain
{
    public class PropertyValueKeyProviderSelector : IPropertyValueKeyProviderSelector
    {
        private readonly IPropertyValueKeyProvider[] _propertyValueKeyProviders;

        public PropertyValueKeyProviderSelector(IPropertyValueKeyProvider[] propertyValueKeyProviders)
        {
            _propertyValueKeyProviders = propertyValueKeyProviders;
        }

        public IPropertyValueKeyProvider Select()
        {
            return Select(s => true);
        }

        public IPropertyValueKeyProvider Select(Func<IPropertyValueKeyProvider, bool> selector)
        {
            return _propertyValueKeyProviders.FirstOrDefault(selector);
        }
    }
}
