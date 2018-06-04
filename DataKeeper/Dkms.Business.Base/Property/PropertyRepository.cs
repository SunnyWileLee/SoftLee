using Dkms.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Business.Base.Property
{
    public abstract class PropertyRepository : DkmsRepository
    {
        protected PropertyRepository(IDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
            
        }
    }
}
