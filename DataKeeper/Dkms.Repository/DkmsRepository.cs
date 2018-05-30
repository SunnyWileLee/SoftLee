using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Repository
{
    public abstract class DkmsRepository : IDkmsRepository
    {
        public event DkmsRepositoryHandler SuccessEvent;
        public event DkmsRepositoryHandler FailEvent;
        public event DkmsRepositoryHandler BeforeEvent;

        private readonly IDbContextProvider _dbContextProvider;

        protected DkmsRepository(IDbContextProvider dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        protected virtual TResult Invoke<TResult>(Func<TResult> func, Func<TResult, bool> predicate)
        {
            BeforeEvent?.Invoke(this, CreateEventArgs());
            var result = func.Invoke();
            if (predicate.Invoke(result))
            {
                SuccessEvent?.Invoke(this, CreateEventArgs());
            }
            else
            {
                FailEvent?.Invoke(this, CreateEventArgs());
            }
            return result;
        }

        protected virtual DkmsRepositoryEventArgs CreateEventArgs()
        {
            return new DkmsRepositoryEventArgs
            {
                ContextProvider = _dbContextProvider
            };
        }
    }
}
