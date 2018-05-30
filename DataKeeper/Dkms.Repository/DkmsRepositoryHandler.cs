using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Repository
{
    public delegate void DkmsRepositoryHandler(object sender, DkmsRepositoryEventArgs args);

    public class DkmsRepositoryEventArgs : EventArgs
    {
        public IDbContextProvider ContextProvider { get; set; }
        public Exception Exception { get; set; }
        public string ErrorMessage { get; set; }
    }
}
