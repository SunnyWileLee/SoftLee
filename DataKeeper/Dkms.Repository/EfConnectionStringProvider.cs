using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Repository
{
    public class EfConnectionStringProvider : IEfConnectionStringProvider
    {
        public string Provide()
        {
            return "DkmsDbConnetion";
        }
    }
}
