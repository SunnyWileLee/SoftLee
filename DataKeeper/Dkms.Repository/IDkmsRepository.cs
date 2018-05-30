using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Repository
{
    public interface IDkmsRepository
    {
        event DkmsRepositoryHandler SuccessEvent;
        event DkmsRepositoryHandler FailEvent;
        event DkmsRepositoryHandler BeforeEvent;
    }
}
