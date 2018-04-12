using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories
{
    public interface IBaseRepository
    {
        event RepositoryHandler SuccessEvent;
        event RepositoryHandler FailEvent;
        event RepositoryHandler CompleteEvent;
        event RepositoryHandler BeforeEvent;
    }
}
