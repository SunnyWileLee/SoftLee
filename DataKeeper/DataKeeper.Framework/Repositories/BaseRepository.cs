using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories
{
    public abstract class BaseRepository: IBaseRepository
    {
        public event RepositoryHandler SuccessEvent;
        public event RepositoryHandler FailEvent;
        public event RepositoryHandler CompleteEvent;
        public event RepositoryHandler BeforeEvent;

        protected virtual void OnSuccess(RepositoryEventArgs args)
        {
            SuccessEvent?.Invoke(this, args);
        }

        protected virtual void OnFail(RepositoryEventArgs args)
        {
            FailEvent?.Invoke(this, args);
        }

        protected virtual void OnComplete(RepositoryEventArgs args)
        {
            CompleteEvent?.Invoke(this, args);
        }

        protected virtual void OnBefore(RepositoryEventArgs args)
        {
            BeforeEvent?.Invoke(this, args);
        }
    }
}
