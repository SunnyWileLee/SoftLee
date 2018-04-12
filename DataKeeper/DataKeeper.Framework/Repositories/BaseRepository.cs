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

        protected virtual void OnSuccess(RepositoryEventArgs e)
        {
            SuccessEvent?.Invoke(this, e);
        }

        protected virtual void OnFail(RepositoryEventArgs e)
        {
            FailEvent?.Invoke(this, e);
        }

        protected virtual void OnComplete(RepositoryEventArgs e)
        {
            CompleteEvent?.Invoke(this, e);
        }

        protected virtual void OnBefore(RepositoryEventArgs e)
        {
            BeforeEvent?.Invoke(this, e);
        }
    }
}
