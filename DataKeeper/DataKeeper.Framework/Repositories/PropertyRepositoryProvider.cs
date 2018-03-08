using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories
{
    public class PropertyRepositoryProvider : IPropertyRepositoryProvider
    {
        public virtual IPropertyRepository Provide()
        {
            return new PropertyRepository();
        }
    }
}
