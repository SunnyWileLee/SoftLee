using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Domain
{
    public interface IPropertyValueKeyProvider
    {
        string Provide<TPropertyValueEntity>();
    }
}
