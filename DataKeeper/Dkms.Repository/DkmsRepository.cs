using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Repository
{
    public abstract class DkmsRepository : IDkmsRepository
    {
        private readonly IDbContextProvider _dbContextProvider;

        protected DkmsRepository(IDbContextProvider dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public IDbContextProvider ContextProvider
        {
            get
            {
                return _dbContextProvider;
            }
        }
    }
}
